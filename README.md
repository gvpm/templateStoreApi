# templateStoreApi

## POST /user/new

Request:
```json
```
Response:
```json
```
## POST /user/login

Request:
```json
```
Response:
```json
```
## GET /product

Response:
```json
```
## GET /product/"productId"

Response:
```json
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
```
Response:
```json
```
## DELETE /product

Request:
```json
```
Response:
```json
```
## GET /cart/"userId"

Response:
```json
```
## POST /cart/

Request:
```json
```
Response:
```json
```
