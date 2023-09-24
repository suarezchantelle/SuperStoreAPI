set IDENTITY_INSERT dbo.Products on 

--insert into dbo.Products(id, title, price, description, image, rate, count,category)
--values(1, 'Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops', 109.95, 'Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday','https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg', 3.9, 120, 'mens clothing')


set IDENTITY_INSERT dbo.Products off

select * from dbo.Products