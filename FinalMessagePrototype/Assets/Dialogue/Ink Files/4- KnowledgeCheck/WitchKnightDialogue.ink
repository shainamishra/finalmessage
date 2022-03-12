// this refers to the number of times the player has encountered the Witch Knight. 0 is for the tutorial room encounter, and 1 is for the Witch Knight room encounter.
VAR interaction = 0 
// This represents if the player has encountered Final Message 2 and determines the presence of the fifth dialogue option. I'm not sure how you're keeping track of this, Shaina, so if the variable name needs to change to match the one in the greater unity project, go for it.
VAR found_finalmessage_2 = false

-> Dialogue

=== Dialogue ===
"Fellow Warrior, Climber of Mount Arar. I am the Witch Knight, the final guardian of the summit. {interaction == 0: I ask you once more, what is your purpose on this mountain?"} {interaction == 1: What is your purpose on this mountain?"}

* "Finding the sun, and basking forever underneath its glorious light."
    -> Dead
* "I have no purpose, only to wander restlessly."
    -> Dead
* "Tatik sent me on my way." 
    "You may pass."
    * * [Leave]
        -> DONE
* "To live the life destined to me by an old witch."
    -> Dead
* {found_finalmessage_2} “I wish to pay respects to the Wizard Knight.”
    “You wish… to pay respects… to the Wizard Knight?”
    * * "I do."
        “...”
        * * * [Continue]
            “I will respect your wishes, Fellow Warrior. However, know that if you so much as touch his grave,
            You won’t have to wait for your shadow.”
            -> DONE

=== Dead ===
-> END


