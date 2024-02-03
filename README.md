# The task:

Implement a service that supports JSON-message exchange to provide information about the list of products in the virtual store, as well as the ability to form an order, remove an item from the list of available items or cancel the order by the user.

As a database you can use a static object in asp.net controller or any relational DBMS you know. As a client you can use any tool for sending and receiving requests. for example: Postman, Insomnia or Restlet plugin for Chrome.

At a minimum, the application should implement the "Product" and "Order" classes, and methods for working with instances of these classes: 
- adding a new item to the list of items available for ordering
- removing an item from the list of items available for ordering
- viewing the list of goods available for ordering
- creating an order for a product (one or several)
- cancel (delete) an order 
- viewing the list of orders for a user

Adding something else to any of the tasks is not prohibited, but can be both a plus (if it is implemented well and does not break out of the internal logic) and a minus (if it creates a problem and/or is not thought out). The main interest is in the internal logic (developer's understanding of the purpose of all parts of his code) and stable operation of the application (ability to handle errors and respond to unexpected / incorrect requests)


# Launching the Application

*Prerequisites:*

- A configured PostgreSQL database.
- A connection string to the database, provided either through an environment variable or in the appsettings.json file located at src/Web/appsettings.json. Specify the connection string as the value for DefaultConnection.

*Steps:*

1. *Launch the solution:*
  - Use CLI commands or Visual Studio to launch the solution.
  - No configuration for HTTPS is needed, so you can disregard SSL certificates.
2. *View the application address:*
  - Once the Web project profile "http" is launched, the application's address will be displayed in the console.

# Application Features

This API offers the following functionalities:

- Order creation: Create orders from your cart.
- Product management: Perform CRUD (Create, Read, Update, Delete) operations on products.
- Cart management: Add, remove, and manage items in your cart.

# Usage

1. *Access the API:*
  - Send HTTP requests to the API address displayed in the console.
  - Note: Unauthenticated users can only view the list of products.
2. *Authentication (Optional):*
  - To perform product editing or other actions requiring authorization, log in using the default administrator credentials:
   - Login: admin@localhost
   - Password: admin1
  - Successful login will provide a Bearer token, which must be included in subsequent authenticated requests.
  - Alternatively, create a non-administrator account for regular usage.
3. *Product Interaction:*
  - View the list of products.
  - Add products to your cart.
4. *Order Creation:*
  - Send a POST request to the orders controller to create an order from your cart.
  - This will clear the items from your cart.

# Steps to reproduce in Postman

1. Launch the app.
2. Get your API address (use it in your future requests).
3. Login to administrator account. ![image](https://github.com/RainDance74/ShopOfPryaniks/assets/104539834/a2fcbed1-f43c-471d-af18-b7a236eb1698)
5. Paste access token to Authorization tab. ![image](https://github.com/RainDance74/ShopOfPryaniks/assets/104539834/d2ae4c93-9de6-4281-b90b-45f486fa7f86)
6. Get the list of products. ![image](https://github.com/RainDance74/ShopOfPryaniks/assets/104539834/d700f37b-630b-48ee-85c1-b17053b0c3dd)
7. Add some pryaniks to the cart. ![image](https://github.com/RainDance74/ShopOfPryaniks/assets/104539834/e698e5cd-4f26-45ed-a78c-61b8eb1d1f2c)
8. Check your cart. ![image](https://github.com/RainDance74/ShopOfPryaniks/assets/104539834/cd12877c-8914-4449-8963-f3400b4338ec)
9. Create an order. ![image](https://github.com/RainDance74/ShopOfPryaniks/assets/104539834/d6b6551f-240a-45b6-a052-cf16bbf7bb2b)
10. Check your order. ![image](https://github.com/RainDance74/ShopOfPryaniks/assets/104539834/5237f8f8-7b5c-4013-9f72-06342c0a68d6)
11. Check products one more time and notice that the amount did change. ![image](https://github.com/RainDance74/ShopOfPryaniks/assets/104539834/cdce0def-aa1e-4922-88b4-8ed4be1ca6f5)
12. Check your cart and you'll see that there is nothing in there. ![image](https://github.com/RainDance74/ShopOfPryaniks/assets/104539834/abcc87ce-69db-42fb-a151-5510c5a3c63b)

That's all! If you want to check other possible requests, and see what it does, [here](https://github.com/RainDance74/ShopOfPryaniks/blob/master/api_documentation.json) is the api documentation.
