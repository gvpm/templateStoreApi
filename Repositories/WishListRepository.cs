using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
namespace StoreApi.Repositories

{
    public class WishListRepository : IWishListRepository
    {
        MongoDatabase _db;
        IUserRepository _userRepository;
        IProductRepository _productRepository;

        IHistoryRepository _historyRepository;
        public WishListRepository(IRepository repository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _db = repository.GetDatabase();
            _userRepository = userRepository;
            _productRepository = productRepository;

        }
        public ExternalCart AddProduct(string userId, string productId)
        {

            var externalCart = Get(userId);

            var query = Query<Cart>.EQ(c => c.UserId, userId);
            Cart cart = _db.GetCollection<Cart>("WishLists").FindOne(query);
            cart.ProductsIds.Add(productId);

            var cartIdQuery = Query<Cart>.EQ(c => c.Id, cart.Id);
            var operation = Update<Cart>.Replace(cart);
            var updateReturn = _db.GetCollection<Cart>("WishLists").Update(cartIdQuery, operation);

            var cartUpdated = _db.GetCollection<Cart>("WishLists").FindOne(query);

            return Get(userId);

        }

        public ExternalCart Get(string userId)
        {
            //caso o usuario nao exista
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }
            //carrinho que vai retornar
            ExternalCart externalCart = new ExternalCart();
            var query = Query<Cart>.EQ(c => c.UserId, userId);
            var cart = _db.GetCollection<Cart>("WishLists").FindOne(query);
            //cria um carrinho para aquele usuario caso nao exista
            if (cart == null)
            {
                Cart newCart = new Cart();
                newCart.UserId = userId;
                _db.GetCollection<Cart>("WishLists").Save(newCart);
                cart = _db.GetCollection<Cart>("WishLists").FindOne(query);

            }
            externalCart.Id = cart.Id;
            externalCart.User = user;
            //copia para remover nao existentes
            var productsIds = new List<string>();
            //= new List<string>(cart.ProductsIds.Select(x => x.Clone()));

            //var productsIds = cart.ProductsIds.;
            //Para cada id de produto no carrinho busca o produto no db de produto
            foreach (var id in cart.ProductsIds)
            {
                var product = _productRepository.Get(id);
                if (product != null)
                {
                    externalCart.TotalValue += product.ProductPriceInCents;
                    externalCart.Products.Add(product);
                    productsIds.Add(product.Id);
                }
 
            }
            //Faz update no carrinho tirando o produto que nao existe
            cart.ProductsIds=productsIds;
            var operation = Update<Cart>.Replace(cart);
            _db.GetCollection<Cart>("WishLists").Update(query, operation);

            return externalCart;
        }



        public ExternalCart RemoveProduct(string userId, string productId)
        {
            var externalCart = Get(userId);

            var query = Query<Cart>.EQ(c => c.UserId, userId);
            Cart cart = _db.GetCollection<Cart>("WishLists").FindOne(query);
            cart.ProductsIds.Remove(productId);

            var cartIdQuery = Query<Cart>.EQ(c => c.Id, cart.Id);
            var operation = Update<Cart>.Replace(cart);
            var updateReturn = _db.GetCollection<Cart>("WishLists").Update(cartIdQuery, operation);

            var cartUpdated = _db.GetCollection<Cart>("WishLists").FindOne(query);

            return Get(userId);
            
        }
    }
}