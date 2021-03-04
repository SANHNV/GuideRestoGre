# GuideRestoGre

## How it works:
You will find a sql script for datageneration and an import.json in the folder Resources in project Data.
The serialization Import and Export are available in the page Home/Serialisation once you run the web project.
Unit tests are working.

## Fonctionnalities:
-	[x] Serialisation and Deserialisation of the data
-	[x] Service Restaurant (CRUD)
-	[x] Unit Test on the two (and query)
- [x] Views : 

| 	       Views          | Status  |               Description     	          |
|         :----:	        |   :--:  |  ---------------------------------------  |
| Home 	                  |   [x]   | welcome Message + 5 best restaurant	      |
| ListRestaurant 	        |   [x] 	| name, descripton, address, info, score  	|
| EditRestaurant 	        |	  [x]   | edit one restaurant 	                    |
| CreateRestaurant 	      |	  [x]   | create new restaurant 	                  |
| DeleteRestaurant 	      |	  [x]   | delete Existing Restaurant              	|
| ListRestaurantByScore 	|	  [x]   | name, datevisite, comment, score       	|
| CreateNote 	            |	  [x]   | create note for restaurant 	              |

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
