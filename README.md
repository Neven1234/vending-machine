# vending-machine
using ASP .net core, identity user
<br>
Auth-Controller  responsible for log in and register
<br>
Product-Controller  responsible for CRUD of the product
<br>
user-Controller  responsible for (Buy,reset,deposit, delete or edit user info)end points
<br>
Run:
user should log in so he can have access to buy if he is a Buyer or sell if he was a Seller
deposit end point only accept (5,10,20,50,100)coins (only accessible  by a user with Buyer role)
buy end point check if the user have enough deposit to buy and if there is enough amount of products avillable for his request (only accessible  by a user with Buyer role)
edit or delete product only can be accessed if it was the seller product and if the user has a seller role
