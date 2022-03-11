/*
The first interaction with with the Lonely Climber in the tutorial level. It needs to have two conversation sets, so this can be broken into two files if need be.
*/

VAR has_been_cut_down = false
VAR initial_interaction_hanging = true
VAR option_taken = false
VAR convo = false

Before you, a man is hanging upside-down, suspended from a tree. His feet are tangled in the rope trap, the mooring for which is nearby, and looks like it could be easily cut through with a hearty swing of a sword.

- (start)
+ [Talk to the {has_been_cut_down == false: Hanging} Man]
    {has_been_cut_down == false:
        -> Hanging
    }
    {has_been_cut_down == true:
        -> Standing
    }
* [Cut him down]
    He falls to the ground with a thud.
    ~ has_been_cut_down = true
    -> start
+ [Leave]
    -> END
    

=== Hanging ===
{initial_interaction_hanging == false:
"I don't suppose you could cut me down, if you wouldn't mind?"
+ [Continue]
    -> start
}
{initial_interaction_hanging == true:
~ initial_interaction_hanging = false
"Ah! Oh, wull hello there... I wasn't, hah, expecting to meet another climber so soon."
+ [Continue]
    "I don't suppose you could cut me down, if you wouldn't mind?"
    + + [Continue]
        -> start
}


=== Standing ===
"Ahhhhhh, light guide me, that's so much better. I can feel my arms again, haha..."
-(opts)
{option_taken == true:
* "How did you get stuck there?"
    "Oh, that, well... I suppose I'm a bit embarrased, what with having been through here so many times already, but I must've missed a danger or two on my first few."
        * * "You've been here many times?"
            "Well, yes, this is the quickest way back into the Valley after my deaths. You know how it is."
            * * * "After your deaths?"
                "Of course! Old Tatik, always looking out for our souls, eh? Oh, unless you mean... Are you new to the Valley?"
                * * * * "Yes, you're the first person I've seen other than that witch."
                    ~convo = true
                    "I suppose she gave you the blessing, then? The one with the medallion? She really wasn't kidding, lose your life out here and you'll wind up back with her. But, on that note, I've taken enough of your time today. You'd best get going. I'm sure we'll see each other again on the climb. Good luck!"
                    -> farewell
}
* "Are you alright?"
    "Ah, yes, thank you. A bruise or two, but nothing I can't handle. And if it is, I'll just have another shot at the mountain anyway, eh?"
        ~option_taken = true
        -> opts
* "Who are you?"
    "Oh, nobody in particular. Just a another climber on the Mount...like you, I presume?"
        ~option_taken = true
        ->opts
-(farewell)
+ {convo} "Farewell."
    -> start