# templateStoreApi

## POST /user/new

Request:
```json
{
    "UserName" : "example",
    "UserEmail" : "example@example",
    "UserPassword" : "pass"
}
```
Response:
```json
{
    "id": "59bf08d0767fc04886fac6b2",
    "userName": "example",
    "userEmail": "example@example",
    "userPassword": "******",
    "userHashPassword": "******"
}
```
## POST /user/login

Request:
```json
{
    "UserName" : "example",
    "UserPassword" : "pass"
}
```
Response:
```json
{
    "id": "59bf08d0767fc04886fac6b2",
    "userName": "example",
    "userEmail": "example@example",
    "userPassword": "******",
    "userHashPassword": "******"
}
```
## GET /product

Response:
```json
[
    {
        "id": "59bf07ce767fc04886fac6b1",
        "productName": "example",
        "productDescription": "example",
        "productLink": "example",
        "productPriceInCents": 20,
        "productCategory": 0
    },
    {
        "id": "59bf091b767fc04886fac6b3",
        "productName": "example",
        "productDescription": "example",
        "productLink": "example",
        "productPriceInCents": 20,
        "productCategory": 0
    },
    {
        "id": "59bf091d767fc04886fac6b4",
        "productName": "example",
        "productDescription": "example",
        "productLink": "example",
        "productPriceInCents": 20,
        "productCategory": 0
    }
]
```
## GET /product/"productId"

Request:
/product/59bf091d767fc04886fac6b4

Response:
```json
{
    "id": "59bf091d767fc04886fac6b4",
    "productName": "example",
    "productDescription": "example",
    "productLink": "example",
    "productPriceInCents": 20,
    "productCategory": 0
}
```
## POST /product

Request:
```json
{
    "ProductName" : "example",
    "ProductDescription" : "example",
    "ProductLink" : "example",
    "ProductPriceInCents" : 20,
    "ProductCategory" : "0"
}
```
Response:
```json
{
    "id": "59bf07ce767fc04886fac6b1",
    "productName": "example",
    "productDescription": "example",
    "productLink": "example",
    "productPriceInCents": 20,
    "productCategory": 0
}

```
## PUT /product

Request:
```json
{
    "id": "59bf091d767fc04886fac6b4",
    "productName": "example",
    "productDescription": "example",
    "productLink": "example",
    "productPriceInCents": 40,
    "productCategory": 0
}
```
Response:
```json
{
    "id": "59bf091d767fc04886fac6b4",
    "productName": "example",
    "productDescription": "example",
    "productLink": "example",
    "productPriceInCents": 40,
    "productCategory": 0
}
```
## DELETE /product

Request:
```json
{
    "Id" : "59bf091d767fc04886fac6b4"
}
```
Response:
```json
{
    "id": "59bf091d767fc04886fac6b4",
    "productName": "example",
    "productDescription": "example",
    "productLink": "example",
    "productPriceInCents": 40,
    "productCategory": 0
}
```
## GET /cart/"userId"

Request:
/cart/59bf08d0767fc04886fac6b2

Response:
```json
{
    "id": "59bf09b1767fc04886fac6b5",
    "user": {
        "id": "59bf08d0767fc04886fac6b2",
        "userName": "example",
        "userEmail": "example@example",
        "userPassword": "******",
        "userHashPassword": "******"
    },
    "products": [],
    "totalValue": 0
}
```
## POST /cart/

Request:
```json
{
	"Operation" : "add",
    "UserId" : "59bf08d0767fc04886fac6b2",
    "ProductId" : "59bf091b767fc04886fac6b3"
}
```

Operation can be either "add" or "remove"

Response:
```json
{
    "id": "59bf09b1767fc04886fac6b5",
    "user": {
        "id": "59bf08d0767fc04886fac6b2",
        "userName": "example",
        "userEmail": "example@example",
        "userPassword": "******",
        "userHashPassword": "******"
    },
    "products": [
        {
            "id": "59bf091b767fc04886fac6b3",
            "productName": "example",
            "productDescription": "example",
            "productLink": "example",
            "productPriceInCents": 20,
            "productCategory": 0
        }
    ],
    "totalValue": 20
}
```


