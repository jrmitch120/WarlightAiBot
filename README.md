#WarlightAiBot

A warlight AI bot framework for the theaigames.

It's currently functional.  The only bot right now is "Sgt. Stupid", who is pretty true
to his name.

More intelligent bots are planned.

##Structure

**Game**: Contains the main constructs for a game.  SuperRegions, Regions, Players, etc.

**Engine**: The warlight command engine.  Commands are broken out individually so they should
be easy to understand and impliment.

**Botting**:  This is where the bot login resides.  To create a new bot, impliment IBot.

###Current Bots
* Sgt. Stupid - A basic bot that doesn't have much in the way of strategic thinking.