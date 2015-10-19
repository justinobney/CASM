CASM
====

Corportate Airplane Scheduling Management
----

The Sections:
----
* Home - Calendar and quick add
* Trip Info
	* Add Trip
	* Edit Trip
* Manage
	* Passengers - CRUD
	* Pilots - CRUD
	* Airplanes - CRUD
	* Settings
	* Users (future, need to think about user story)

Home
----
* Legend
* Quick Add
	* Will have: date, airplane, name, location
	* Upon quick add, will make a new trip using location entered 
	  departing from default departure defined in settings
* Calendar
	* Initial dev will include grabbing top 200 trips

Add Trip
----
* Will start out like the Home "quick add," but include a place for departing location
* Once locations saved, will transition into "edit" mode

Edit Trip
----
* Editable "trip header data"
* Waypoint add section
* Drag waypoints to reorder
* Loose/no validation on departing/arriving time (possible warning if it doesnt make sense)
* To edit waypoints, you "expand them"
* Need to think about how/when to save. Maybe autosave when model is valid. (but throttle save)

TODO
----
* [ ] - Neil: Controller actions for CRUD on Passengers, Pilots, Airplanes
* [ ] - Justin: UI on Passengers, Pilots, Airplanes
* [ ] - Justin: Domain needs for "settings"
* [ ] - Neil: IRepository updates
* [ ] - Neil: Add any fixes or thoughts

[![Contact me on Codementor](https://cdn.codementor.io/badges/contact_me_github.svg)](https://www.codementor.io/justinobney?utm_source=github&utm_medium=button&utm_term=justinobney&utm_campaign=github)
