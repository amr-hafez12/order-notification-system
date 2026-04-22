*Description

This project simulates a simple order notification system. When an order is placed, multiple services such as Email and SMS are notified using Delegates and Events.

*Delegate:

A delegate (OrderHandler) is used to define the method signature for all notification methods (Email and SMS).

*Event:

An event (watcher) is used inside the OrderService class to notify all subscribed services when a new order is placed.

*Lambda Expression:

A lambda expression is used to log order messages:orderService.watcher += msg => Console.WriteLine(...);

*Extension Method:

An extension method (formatted) is created to format the order message before sending notifications.

*Func / Predicate:

A Func<string, bool> is used as a filter to control whether notifications are sent based on a condition (e.g., order length).