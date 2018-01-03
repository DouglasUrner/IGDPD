## Chapter 29 - Prototype 2: Mission Demolition

A physics based game loosely inspired by
[Angry Birds](https://en.wikipedia.org/wiki/Angry_Birds).

### Concepts / Things to Teach

* Physics system
  - Sleep
  - Quirks: intersecting blocks
* Singleton pattern
* Cloud generation (could generalize as a mastery demonstration)
* Projectile trails
* Player feedback
* Color models (RGBA)
* Working with prefabs

### Mastery Extensions

Tasks that students can take on to demonstrate mastery of the
concepts taught in this prototype game – arranged roughly in order
of increasing difficulty:

* Build a deployable version for the web or a desktop computer.
* Build deployable version for a touch device.
* Implement the projectile trails using Unity's built-in Trail
Renderer effect and identify the problems with it that requires
us to implement our own based on the Line Renderer.
* Design a reusable cloud system based on the one developed for
this game.
* Convert the cloud system into a reusable component.

### Problems

Things that students might notice or get hung up on as they build
the game:

* Null reference exception in Unity while Adding More Castles -
possibly due to deleting the castle from the Hierarchy.

### Bugs

* Castle 3 sometimes collapses on its own shortly after instantiation.
