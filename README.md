# GuideRestoGre

## Fonctionnalities:
-	[x] Serialisation and Deserialisation of the data
-	[x] Service Restaurant (CRUD)
-	[x] Unit Test on the two 
- [ ] Views : 

| Views 	| Status  | Description 	|
| :----:	| :--:    | ----------	|
| Home 	  |   [x]   | welcome Message + 5 best restaurant	|
| ListRestaurant 	|  [ ] 	| name, Address, datevisite, score	|
| EditRestaurant 	|	 [ ]  | edit one restaurant 	|
| CreateRestaurant 	|	 [ ]  | create new restaurant 	|
| DeleteRestaurant 	|	 [ ]  | delete Existing Restaurant 	|
| ListRestaurant 	|	 [ ]  |  name, Address, datevisite, score 	|
| CreateNote 	    |	 [ ]  | create note for restaurant 	|

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
