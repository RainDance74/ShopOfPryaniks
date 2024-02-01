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
