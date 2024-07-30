Caching: 
- may be applied on saving the list of candidates
- in ApplicationCore when querying the list of candidates, we might save it in cache
- in Controller, when getting the list of candidates, we might check the cache, if it doesn't exist, take it from the database and also save it in cache
- there could be an event for adding/ updating a candidate and when this actions happen a notification should be published and based on that, the cached list of candidates should be updated


Improvements:
- use SignalR to send the list of candidates to UI when updates happen to it

Total time spent: 8 hours
