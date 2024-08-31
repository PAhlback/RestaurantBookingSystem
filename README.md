# RestaurantBookingSystem
I den här uppgiften ska du utveckla ett backend-system för att hantera bokningar, kundinformation och menyer för en restaurang. 
Systemet kommer att möjliggöra hantering av bord, bokningar, kunder och menyer genom ett Web API, vilket ger restaurangen möjlighet att effektivt administrera sina resurser.

## Endpoint documentation
All categories (controllers) include, but are not limited to, the following endpoints:
- Get All
- Get One By Id. Id sent through route parameter.
- Post
- Put
- Delete

### Customers
#### GET: /api/Customers
##### Responses:
- 200 Ok
```json
[
  {
   "id": 1,
   "name": "Pelle Larsson",
   "email": "pelle@larsson.com",
   "phone": null
  }
]
```
- 404 Not Found
	- If no customers exist in the database. Will be changed to return 200 Ok with a null list.
- 400 Bad Request
	- For catching anything unexpected.

#### GET: /api/Customers/{id}
##### Responses:
- 200 Ok
```
{
  "id": 1,
  "name": "Pelle Larsson",
  "email": "pelle@larsson.com",
  "phone": null,
  "reservations": []
}
```
- 400 Bad Request
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

#### POST: /api/Customers
##### Request Body:
```
**CustomerDTO**
{
  "name": "string",
  "email": "string",
  "phone": "string" or null
}
```
##### Responses:
- 201 Created
- 400 Bad Request
	- For catching anything unexpected.

#### PUT: /api/Customers/{id}/update
Takes an id from the route parameter, and a CustomerDTO with the updated information.
##### Request Body:
```
**CustomerDTO**
{
  "name": "string",
  "email": "string",
  "phone": "string" or null
}
```
##### Responses:
- 204 No Content
- 400 Bad Request
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

#### DELTE: /api/Customers/{id}/delete
Takes an id from the route parameter, and a CustomerDTO with the updated information.
##### Request Body:
```
**CustomerDTO**
{
  "name": "string",
  "email": "string",
  "phone": "string" or null
}
```
##### Responses:
- 204 No Content
- 400 Bad Request
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.