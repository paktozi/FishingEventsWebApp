# FishingEventsWebApp

This is an application for fishing events or tournaments.
Unregistered users can only view events and the general ranking, for the rest they must log in.

Logged in users can create events, edit or delete them if they created them. They can also join other events, post comments about certain events. They have access to all locations and check the forecast and current weather conditions, they can also check the weather in any city. They can view all fish species, all users and their catches.

Administrators can create events but cannot participate. They can delete other events, edit or delete inappropriate comments, add and delete locations, add or delete fish species. They can also add or delete fishing catches of participants in the events.

The global administrator has all the rights of the administrator plus the ability to delete users, give and take away admin rights. He also cannot participate in events.
When a user is deleted, his comments, fishing catches, role (if an administrator), and event participation will also be deleted. If the deleted user is an event organizer, the global administrator becomes the event organizer upon deletion of the user.


To use the weather forecast, you need to register at: https://www.visualcrossing.com/ to get an API key, which you need to enter in the "GetWeatherAsync" action in the "WeatherService" class.


Login: user1@abv.bg user2@abv.bg, user3@abv.bg, user4@abv.bg, user5@abv.bg with Pass:qazwsx

Login: admin@abv.bg Pass:qazwsx

Login: globaladmin@abv.bg Pass:qazwsx


<img width="1280" alt="123" src="https://github.com/user-attachments/assets/0a57bcf0-ea7f-44c5-a872-686c92606c60">
