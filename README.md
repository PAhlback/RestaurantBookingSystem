# RestaurantBookingSystem
I den här uppgiften ska du utveckla ett backend-system för att hantera bokningar, kundinformation och menyer för en restaurang. 
Systemet kommer att möjliggöra hantering av bord, bokningar, kunder och menyer genom ett Web API, vilket ger restaurangen möjlighet att effektivt administrera sina resurser.

## Endpoint documentation
All categories (controllers) include, but are not limited to, the following endpoints:
- Get All
- Get One By Id
- Post
- Put
- Delete

### Customers
#### GET: /api/Customer
- Response:
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


#### GET: /api/Customer/{id}
- 