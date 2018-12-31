# Unity-2d-Prediction-System

![prediction](https://user-images.githubusercontent.com/24853166/50562918-86544280-0d29-11e9-96ad-395e3a918087.png) 
This Project Created on Unity 2018.2.0f
Without throwing the ball, This is helps to predict the  all ball position.

What you need to do ,

1. Hold down the mouse , all positions of the ball will be shown.
2. When you left , the ball will be thrown automatically.

I use velocity. And prediction system work on velocity. No AddForce.

Prediction System Script

public Rigidbody2D rigi; // It is your ball rigidbody

Prediction_Objects // Your prediction game object. It is draw the path.

speed  // Your ball's speed. Prediction system . It will adapt to the speed of the ball. And it will be right

space // Distance between prediction objects

And i use Pooling.

Thanks Everybody!
