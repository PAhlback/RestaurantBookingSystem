# RestaurantBookingSystem
In this school assignment the task was to create a RESTful API with CRUD operations for a table reservation system for a restaurant. 
The program handles the tables, customers, menu, and reservations for the restaurant.

---

## Endpoint documentation
All categories (controllers) include, but are not limited to, the following endpoints:
- Get All
- Get One By Id (Id is sent through route parameter)
- Post
- Put
- Delete

---

### Customers
#### GET: /api/Customers
Returns a list of all customers.
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
```json
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
```json
CustomerDTO
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
```json
CustomerDTO
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

#### DELETE: /api/Customers/{id}/delete
Takes an id from the route parameter.
##### Responses:
- 204 No Content
- 400 Bad Request
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

---

### MenuItems
#### GET: /api/MenuItems
Returns a list of all menu items.
##### Responses:
- 200 Ok
```json
[
  {
    "id": 1,
    "name": "Pasta Carbonara",
    "description": "Spaghetti with pancetta, egg, Parmesan, Pecorino, and black pepper.",
    "price": 195,
    "isAvailable": true
  },
  {
    "id": 2,
    "name": "Margherita",
    "description": "Tomato sauce, fresh mozzarella, basil, and extra virgin olive oil.",
    "price": 175,
    "isAvailable": true
  }
]
```
- 400 Bad Request
	- For catching anything unexpected.

#### GET: /api/MenuItems/{id}
##### Responses:
- 200 Ok
```json
{
  "id": 1,
  "name": "Pasta Carbonara",
  "description": "Spaghetti with pancetta, egg, Parmesan, Pecorino, and black pepper.",
  "price": 195,
  "isAvailable": true
}
```
- 400 Bad Request
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

#### POST: /api/MenuItems
##### Request Body:
```json
MenuItemDTO
{
  "name": "string",
  "description": "string",
  "price": 0,
  "isAvailable": true
}
```
##### Responses:
- 201 Created
- 400 Bad Request
	- For catching anything unexpected.

#### PUT: /api/MenuItems/{id}/update
Takes an id from the route parameter, and a MenuItemDTO with the updated information.
##### Request Body:
```json
MenuItemDTO
{
  "name": "string",
  "description": "string",
  "price": 0,
  "isAvailable": true
}
```
##### Responses:
- 204 No Content
- 404 Not Found
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

#### DELETE: /api/MenuItems/{id}/delete
Takes an id from the route parameter.
##### Responses:
- 204 No Content
- 404 Not Found
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

---

### Reservations
#### GET: /api/Reservations
Returns a list of all reservations.
##### Responses:
- 200 Ok
```json
[
  {
    "id": 5,
    "numberOfGuests": 4,
    "dateAndTime": "2024-09-01T18:00:00",
    "customer": {
      "id": 1,
      "name": "Pelle Larsson",
      "email": "pelle@larsson.com",
      "phone": null
    },
    "table": {
      "id": 3,
      "tableNumber": 3,
      "numberOfSeats": 4
    }
  },
  {
    "id": 6,
    "numberOfGuests": 4,
    "dateAndTime": "2024-09-01T18:00:00",
    "customer": {
      "id": 1,
      "name": "Pelle Larsson",
      "email": "pelle@larsson.com",
      "phone": null
    },
    "table": {
      "id": 4,
      "tableNumber": 4,
      "numberOfSeats": 4
    }
  }
]
```
- 400 Bad Request
	- For catching anything unexpected.

#### GET: /api/Reservations/{id}
##### Responses:
- 200 Ok
```json
{
  "id": 5,
  "numberOfGuests": 4,
  "dateAndTime": "2024-09-01T18:00:00",
  "customer": {
    "id": 1,
    "name": "Pelle Larsson",
    "email": "pelle@larsson.com",
    "phone": null
  },
  "table": {
    "id": 3,
    "tableNumber": 3,
    "numberOfSeats": 4
  }
}
```
- 400 Bad Request
	- For catching anything unexpected.

#### POST: /api/Reservations
##### Request Body:
```json
ReservationDTO
{
  "numberOfGuests": 0,
  "dateAndTime": "2024-08-31T10:06:15.334Z",
  "customerEmail": "string",
  "customerName": "string",
  "customerPhone": "string"
}
```
##### Responses:
- 201 Created
- 400 Bad Request
    - From InvalidOperationException for when the party size is bigger than the number of seats around the biggest table.
- 400 Bad Request
	- For catching anything unexpected.

#### PUT: /api/Reservations/{id}/update
Takes an id from the route parameter, and a ReservationDTO with the updated information.
##### Request Body:
```json
ReservationDTO
{
  "numberOfGuests": 0,
  "dateAndTime": "2024-08-31T10:06:15.334Z",
  "customerEmail": "string",
  "customerName": "string",
  "customerPhone": "string"
}
```
##### Responses:
- 204 No Content
- 404 Not Found
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

#### DELETE: /api/Reservations/{id}/delete
Takes an id from the route parameter.
##### Responses:
- 204 No Content
- 404 Not Found
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

---
   
### Tables
#### GET: /api/Tables
Returns a list of all tables.
##### Responses:
- 200 Ok
```json
[
  {
    "id": 1,
    "tableNumber": 1,
    "numberOfSeats": 6
  },
  {
    "id": 2,
    "tableNumber": 2,
    "numberOfSeats": 6
  },
]
```
- 404 Not Found
    - If no tables are found. Will be removed in favor of returning an empty list.
- 400 Bad Request
	- For catching anything unexpected.

#### GET: /api/Tables/{id}
##### Responses:
- 200 Ok
```json
{
  "id": 3,
  "tableNumber": 3,
  "numberOfSeats": 4,
  "reservations": [
    {
      "id": 5,
      "numberOfGuests": 4,
      "dateAndTime": "2024-09-01T18:00:00",
      "customerName": "Pelle Larsson",
      "customerEmail": "pelle@larsson.com"
    }
  ]
}
```
- 404 Not Found
    - From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

#### POST: /api/Tables
##### Request Body:
```json
TableDTO
{
  "tableNumber": 0,
  "numberOfSeats": 0
}
```
##### Responses:
- 201 Created
- 400 Bad Request
	- For catching anything unexpected.

#### PUT: /api/Tables/{id}/update
Takes an id from the route parameter, and a TableDTO with the updated information.
##### Request Body:
```json
TableDTO
{
  "tableNumber": 0,
  "numberOfSeats": 0
}
```
##### Responses:
- 204 No Content
- 404 Not Found
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

#### DELETE: /api/Tables/{id}/delete
Takes an id from the route parameter.
##### Responses:
- 204 No Content
- 404 Not Found
	- From KeyNotFoundException indicating {id} was not found in database.
- 400 Bad Request
	- For catching anything unexpected.

#### GET: /api/Tables/check-for-available-tables/{dateAndTime}
Gets all the tables that are available in a 2 hour window from a specified date and time. Date and time are sent in 
via route parameter.
##### Responses:
- 200 Ok
```json
[
  {
    "id": 1,
    "tableNumber": 1,
    "numberOfSeats": 6
  },
  {
    "id": 2,
    "tableNumber": 2,
    "numberOfSeats": 6
  },
]
```
- 400 Bad Request
	- For catching anything unexpected.