# duel implementation mvp1

two capsules representing combatants
	left capsule is player, right is enemy
	each capsule has a blue rectangle child object representing shield
	each capsule has a red rectangle child object representing sword

orb at the top of the screen pulsates to the 'beat'
each fighter has HP
player can press triangle for hi attack, square for med attack, x for lo attack

## act on the beat

only the presses that happen on a beat will start an action (attack or defend). The player does not have to get it exactly on the beat; there is a slight grace period before and after the 'beat' where it will still register, in the order of milliseconds.
each player action has different cooldowns

attack:
	- hi : 3 beat
	- med : 2 beat
	- lo : 1 beat

defend:
	- hi, med, lo : 1 beat

during the cooldown periods, no actions will be performed

## ai

the enemy aims on every 7th beat, and attacks on every 8th beat.
the attack target point (hi, med, lo) is randomly chosen
aim: 
	red rectangle moves to the stance, telegraphing its attack
		- hi : top of capsule
		- med : middle of capsule
		- lo : bottom of capsule
attack:
	red rectangle moves straight towards the other capsule, damage (or defense) is registered, and then returns to neutral position

defend:
	blue rectange moves to protect its owner with the same positioning system as the 'aim' action.

## win/loss

when one combatant runs out of hp, it dies. combat is stopped, and we can restart/quit.
