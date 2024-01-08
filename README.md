# LabbProjektApi

*Anropen Gjordes med Postman under utveckling*
------------------------------------------------------------------------------------------
Anropen mot API:
---------
- Hämta alla personer i systemet:
    http://localhost:5003/users
---------  
- Hämta alla intressen som är kopplade till en specifik person:
    http://localhost:5003/users/1/interests
---------  
- Hämta alla länkar som är kopplade till en specifik person:
    http://localhost:5003/users/1/interestlinks
---------
- Koppla en person till ett nytt intresse:
   !!OBS: Ändra till POST!! Och skriv Json-format mot endpoint.
    http://localhost:5003/users/link-user-to-interest
 {
    "interestsid": 1,
    "usersid": 1
}
---------
- Lägga in nya länkar för en specifik person och ett specifikt intresse:
   !!OBS: Ändra till POST!! Och skriv Json-format mot endpoint.
    http://localhost:5003/add-interest-link
  Exempel:
 {
    "link": "test.com",
    "title": "testing the controller",
    "interestsid": 1,
    "usersid": 1
}
---------
------------------------------------------------------------------------------------------

Bild på UML Diagram:
![UML-Diagram](https://github.com/Balos87/LabbProjektMiniApi/assets/145317796/07452fbf-300f-420b-a750-830a5628d8b2)

Bild på ER Diagram:
![ER-Diagram](https://github.com/Balos87/LabbProjektMiniApi/assets/145317796/f18448a3-1fb5-4dfb-8f9d-902b0031f9aa)


------------------------------------------------------------------------------------------


