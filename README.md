# Programming Principles

## Single Responsibility Principle (SRP):

Each class in the code has one responsibility. For example, PriceCalculator is responsible for calculating the total amount for accommodation

## Open/Closed Principle (OCP):

The code is designed to be open to extension but closed to modification. New search strategies can be added by implementing the ITotalCostCalculator interface and extending the PriceCalculatory class without changing existing code.

## Interface Segregation Principle (ISP):

I have two interfaces for implementing the PriceCalculator class, they were divided into (ITotalCostCalculator and IStayDurationCalculator) and report. In this way, classes are not required to implement interfaces that are not relevant.

## Dependency Inversion Principle (DIP):

The PaymentType class depends on the IPaymentStrategy abstraction rather than on a specific payment type implementation. This allows payment implementations to be replaced without affecting the code of the PaymentType class, which is consistent with the principle

## Keep It Simple, Stupid (KISS):

The methods are written very simply and easy to read. Do not save lines on purpose.

## Don't Repeat Yourself (DRY):

All code is written without repetition.

# Design Patterns

## Strategy Pattern:

I use PaymentType to select the payment type (terminal or cash). Allows you to supplement the code if other payment types appear

## Singleton Pattern:

I use it to be able to create only one guest in the Guest class in order to register him in a room. After a successful or unsuccessful write, the single instance can be erased to allow a new guest to write.

## Builder Pattern:

Allows you to create rooms and build them with the parameters that I need. To use this pattern more productively, it was possible to use a loop and take data from the database, but for the demo version, in order not to connect the database, it was decided to create instances manually.

# Refactoring Techniques

## Add Parameter

In the CalculateCostStay method I need two parameters in order to calculate the total price for the stay, it is taken from two classes (Guest (stay time) and Room (Cost per night))

## Encapsulate Field:

In the Guest class, the PassportNumbe field is made a private get , which allows it to be encapsulated from outputting data that the user should not see

## Inline Temp

In the PriceCalculator class, the CalculateCostStay method did not use an extra variable; the method immediately outputs what is expected from the method 
(  return new Money(whole,fractions,hotel.PricePerNight.Currency); )


