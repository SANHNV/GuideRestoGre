# GuideRestoGre

## Fonctionnalities:
-	[x] Serialisation and Deserialisation of the data
-	[x] Service Restaurant (CRUD)
-	[x] Unit Test on the two 
- [ ] Views : 

| Views 	                | Status  | Description 	|
| :----:	                | :--:    | ----------	|
| Home 	                  |   [x]   | welcome Message + 5 best restaurant	|
| ListRestaurant 	        |  [x] 	| name, Address, datevisite, score	|
| EditRestaurant 	        |	 [x]  | edit one restaurant 	|
| CreateRestaurant 	      |	 [x]  | create new restaurant 	|
| DeleteRestaurant 	      |	 [x]  | delete Existing Restaurant 	|
| ListRestaurantByScore 	|	 [ ]  |  name, Address, datevisite, score 	|
| CreateNote 	            |	 [ ]  | create note for restaurant 	|

## Data model:
### Restaurant:
- ID
- Name
- PhoneNumber
- Description
- Mail
- Address
- Grade
### Address:
- ID
- Street
- ZipCode
- City
- RestaurantId
### Grade:
- ID
- LastVisitDate
- Score
- Comment
- RestaurantId
