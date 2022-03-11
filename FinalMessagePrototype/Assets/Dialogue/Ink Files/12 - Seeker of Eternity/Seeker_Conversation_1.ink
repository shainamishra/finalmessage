-> seeker_bootup

=== seeker_bootup ===
VAR firstAsk = 1
VAR askedChimes = 0
VAR askedImmort = 0
VAR confronted = 0
*[First encounter]
-> seeker1_first1
*[Subsequent encounter]
-> seeker1_options1

=== seeker1_first1 ===
Ah, another climber.

*[Listen]
-> seeker1_first2
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_first2 ===
Salutations. My name would be of little import to you, so you may call me by what I am: Seeker of Eternity.

*[Listen]
-> seeker1_first3
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_first3 ===
I am a scholar, and once I sought to summit this Mount as I am certain you do now. I wanted to study it you see, learn why so many are drawn to this grueling climb.

*[Listen]
-> seeker1_first4
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_first4 ===
But in my journey, I came to realize that nothing the Summit has to offer could possibly equal the gift given freely by the old witch at the Mountain's base.

*[Listen]
-> seeker1_first5
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_first5 ===
Immortality!

*[Listen]
-> seeker1_first6
*[Interrupt]
-> seeker1_interrupt1

==seeker1_first6 ===
Facing the Shadow of death is a small price to pay for victory over it, I have learned. And I have learned much more, in the long time I have spent with the Mount as my teacher.

*[Listen]
-> seeker1_options1
*[Interrupt]
-> seeker1_interrupt1



=== seeker1_options1 ===
Tell me, little climber, is there anything{firstAsk == 0: else} you would have me teach you?

* {askedChimes == 0} "Your chimes."
-> seeker1_chimes1
*"Tatik."
-> seeker1_tatik1
*"Immortality."
-> seeker1_immort1
* {askedImmort == 1 && confronted == 0} "Climb with me."
-> seeker1_bidClimb1
* {askedImmort == 1 && confronted == 0} "Why keep going?"
-> seeker1_bidFall1
*"No."
-> seeker1_farewell



=== seeker1_chimechoice ===
*[Has Chime Staff]
-> seeker1_chimesong1
*[Does not have Chime Staff]
-> seeker1_chimestaff1


=== seeker1_chimes1 ===
~ firstAsk = 0
~ askedChimes = 1
Ah, yes. The charm bells.

*[Listen]
-> seeker1_chimes2
*[Interrupt]
-> seeker1_interrupt1


=== seeker1_chimes2 ===
We— no, the scholars of the university use them in their studies, but their ancestral home is here on Mount Arar.

*[Listen]
-> seeker1_chimes3
*[Interrupt]
-> seeker1_interrupt1


=== seeker1_chimes3 ===
If you seek the summit, there is a song you must learn to play on them. You will need an instrument, of course, a staff like my own.

*[Listen]
-> seeker1_chimechoice
*[Interrupt]
-> seeker1_interrupt1


=== seeker1_chimesong1 ===
Ah! You have a chime staff. Very good.

*[Listen]
-> seeker1_chimesong2
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimesong2 ===
Now, observe the staff. It has three bells of differing sizes, yes?

*[Listen]
-> seeker1_chimesong3
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimesong3 ===
These produce different tones. This is obvious, but I'm trying to keep it simple for you.

*[Listen]
-> seeker1_chimesong4
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimesong4 ===
The Chime Gate, which leads into the caves that will take you to the Summit, has three bells in much the same way.

*[Listen]
-> seeker1_chimesong5
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimesong5 ===
To open it, you must strike them in a precise order to create the song that the Gate listens for.

*[Listen]
-> seeker1_chimesong6
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimesong6 ===
Your instrument's chimes will resonate with the Gate's. It will not open without this resonance.

*[Listen]
-> seeker1_chimesong7
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimesong7 ===
I am going to teach you the order of chimes to perform the song now. Observe carefully and remember, I have no patience for repetition.

*[Listen]
-> seeker1_chimesong8
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimesong8 ===
[This can either be a short, simple cutscene of the bells being hit in the correct order, or the Seeker can just tell the player. I'd prefer a "cutscene" but we all know how that goes.]

*[Listen]
-> seeker1_chimesong9
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimesong9 ===
Good. Now you may enter the Caves and begin your final ascent, if you wish. Foolishness, but who am I to stop you?

*[Back]
-> seeker1_options1

=== seeker1_chimestaff1 ===
No, you may not have mine. I need it for my studies, and the song you will need it for is something of a point of no return.

*[Listen]
-> seeker1_chimestaff2
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimestaff2 ===
You would be unable to return it to me. And even though I would have Eternity to construct myself a new one, I'm rather fond of this one.

*[Listen]
-> seeker1_chimestaff3
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimestaff3 ===
It was a gift from a departed friend of mine, you see.

*[Listen]
-> seeker1_chimestaff4
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimestaff4 ===
So, you will need to find one of your own. The Mount does wish to be climbed, despite its efforts to appear otherwise, so I do believe it will provide.

*[Listen]
-> seeker1_chimestaff5
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_chimestaff5 ===
I suspect you need only explore its slopes. Perhaps you already know where to find one, hm?

*[Back]
-> seeker1_options1



=== seeker1_tatik1 ===
~ firstAsk = 0
Ah, Tatik Arar, the Grandwitch of the Mount. She is kind, yes she must be, giving away the secrets to Immortality as if they were a grandmother's baking.

*[Listen]
-> seeker1_tatik2
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_tatik2 ===
I am already quite ancient, and she has been here far longer than I. Who is to say how many ages she has spent here, watching over her domain from her cottage at its base.

*[Listen]
-> seeker1_tatik3
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_tatik3 ===
She is the guardian of this place, and of its Summit. Yet, she does earnestly try to aid those who would come here and Seek it.

*[Listen]
-> seeker1_tatik4
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_tatik4 ===
Her methods are unorthodox indeed...yet, who can deny their effect? None have reached the Summit. The foolish die trying, and the wise abandon their futile climb and reap Tatik's generous gift instead.

*[Listen]
-> seeker1_tatik5
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_tatik5 ===
The power to rip the Shadow of Death out of the living is a great one indeed. I believe we should be grateful that she is a kindly guardian, and not a vengeful one.

*[Back]
-> seeker1_options1




=== seeker1_immort1 ===
~ firstAsk = 0
~ askedImmort = 1
It is Tatik's gift to us the Climbers. I believe she called it a curse, and though the spell certainly bears some cladistic similarities to the curse family I would argue it is largely benign.

*[Listen]
-> seeker1_immort2
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_immort2 ===
Ah, but such academic technicalities are beyond a layperson such as yourself. Suffice it to say, the magic that allows you to continue your climb through death is not immediately dangerous to your soul.

*[Listen]
-> seeker1_immort3
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_immort3 ===
It will continue to resurrect you at the break of dawn, forever.

*[Listen]
-> seeker1_immort4
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_immort4 ===
Well, it will if you have any sense in you. The spell can be broken in two ways:

*[Listen]
-> seeker1_immort5
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_immort5 ===
One, you become the first to Summit this Mount and it is washed away by the Sun's radiance. I find this unlikely, although there is certainly no harm in trying.

*[Listen]
-> seeker1_immort6
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_immort6 ===
Two, your will breaks and you lose the desire to go on. This is how every climber before you has died: they swallowed the black truth concerning the futility of their climb, and their Shadows caught up to them.

*[Listen]
-> seeker1_immort7
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_immort7 ===
The Shadows, of course, represent the spell's only true downside. In order to prevent each death from being your last, Tatik seems to have externalized our connection to it.

*[Listen]
-> seeker1_immort8
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_immort8 ===
This creates a sort of mirror image of each Climber, a living Ghost. I'm sure you've met yours already.

*[Listen]
-> seeker1_immort9
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_immort9 ===
But not to worry. The most your Shadow of Death can do to you is kill you.

*[Listen]
-> seeker1_immort10
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_immort10 ===
Which isn't such a terrible thing when you know you're going to wake up the next morning regardless.

*[Back]
->seeker1_options1

=== seeker1_bidClimb1 ===
~ confronted = 1
Hah! I'm certain you could use the help!

*[Listen]
-> seeker1_bidClimb2
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_bidClimb2 ===
No.

*[Listen]
-> seeker1_bidClimb3
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_bidClimb3 ===
Perhaps someday I'll find time for the Summit, but even with Eternity spread out before me this Mount has many secrets worth unraveling. I'll remain on its slopes for another age or two, I suspect.

*[Listen]
-> seeker1_bidClimb4
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_bidClimb4 ===
Only a couple ages...how brief that sounds...no no, I'll need longer than that...

*[Back]
-> seeker1_options1

=== seeker1_bidFall1 ===
~ confronted = 1
How morbid you are! And your Shadow hasn't taken you yet? Odd.

*[Listen]
-> seeker1_bidFall2
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_bidFall2 ===
I keep going because there is much worth studying here still!

*[Listen]
-> seeker1_bidFall3
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_bidFall3 ===
It has taken me lifetimes to learn as much as I have, and it will doubtless take lifetimes more to exhaust this Mount's curriculum.

*[Listen]
-> seeker1_bidFall4
*[Interrupt]
-> seeker1_interrupt1

=== seeker1_bidFall4 ===
I think I will Seek this place until the Sun goes dark, and even that won't be enough time I fear...

*[Back]
-> seeker1_options1



=== seeker1_interrupt1 ===
I see. You have not time for my ramblings? How strange. Do you not know that you are one of the very, very few who truly have all the time in the world?

*[Listen]
-> seeker1_interrupt2

=== seeker1_interrupt2 ===
No matter. Run along then, and return once the Mount has taught you some patience.

*[Leave]
->end

=== seeker1_farewell ===
Fare well in your ascent. Do let me know if you'll join me someday.

*[Leave]
->end

=== end ===
-> END