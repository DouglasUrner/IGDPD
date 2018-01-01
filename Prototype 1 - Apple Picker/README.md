## Apple Picker

Based on [Kaboom!](https://en.wikipedia.org/wiki/Kaboom!)
– and Avalanche and Lost Luggage and Eggomania…

Allow about 8 hours of relatively focused student time
to complete this prototype.

### Concepts / Things to Teach

* Strategy for building out a game:
  - Art / game bits
  - Flesh out object before creating prefab
  - Naming conventions
  - Pseudocode and comments
  - Tuning in the Inspector
  - Game controller on the Main Camera
  - Duplicating scenes for testing
* Working with GameObjects
  - Creating GameObjects
  - Components
  - Instantiationg GameObjects
  - Destroying GameObjects
* Creating Materials
* Tags
* Prefabs
* Physics - Rigidbody
  - Use gravity
  - isKinematic
  - FixedUpdate
  - Physics layers
* Camera Setup

### Mastery Extensions

* Use ints to store the scores in the UI rather than parsing strings.

* Make the points per Apple a configurable variable

* Keep a List of active Apples so that the whole GameObject space doesn't need to be searched when a basket is destroyed.

* Accumulate some Apples in Baskets as they are caught so that it looks like something is happening.

* Build and test the game on an iOS or Android device.

* Dynamically adjust challenge - increase speed if player gets a long run of
caught Apples. Could also play with the odds of changing direction or the rate
at which Apples are dropped.

* Be less abrupt (and presumptive) in ending the game.

* Collect tuning parameters in one script.

### Problems

### Bugs

1. Basket color (alpha) on restart.