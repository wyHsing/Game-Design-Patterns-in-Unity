# Design-Patterns
 
# Event

This is an example that when the player needs to record the game data like killing times, maybe for personal records, maybe for task records. Due to multiple uses, we need to seperate the player and the character, whenever the character kills, the player, as a subscriber, will notices and does the record. Besides, if you have a task system, the individual task will be the subscriber too, but the character doesn't care who is listening, the character just does its business.  

I was confused with the logic of events for a while, yet I found a way to decide who is using the delegate functions and events.  
Who is the broadcaster, who has the delegate functions and events, waiting for someone adding.  
Who is the listener, who is going to know the existence of the broadcaster ahd it/other manager will ask the broadcaster event handler(like the notification, the ring bell) to add its functions.  

In this Example, "Character" is the broadcaster, "Player" is the subscriber/listener.  
Player will listen Character's killing action, when Character do the Kill(), Player will know it's triggered, and Player will do its response, which is added to the handler before, AddKill(ECharacter _eCharacter).  
If you want to add a task system, you and just do like what Player did, Character will be the same, it just the data.  

Later I will change to EventHandlerArgs Version.

# Singleton

I learned Singleton from Kencoder(https://kendevlog.wordpress.com/2018/08/14/unity%E5%AD%B8%E7%BF%92%E7%AD%86%E8%A8%98%EF%BC%9A%E5%A6%82%E4%BD%95%E5%AF%A6%E7%8F%BEsingleton/), for this testing I didn't edit much, yet I will make my own version on my pratical use in game development and replace this part or show in the new project.  
Becuse basically almost all codes are from Kendcoder's share, I won't explain anything, please go to his/her website.
