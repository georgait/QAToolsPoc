# QA Tools (poc)

## Overview

The Screenplay Pattern is a popular design pattern for software testing that tries to give automated testing a modular, scalable, and maintainable approach. It is based on the Serenity BDD library and has gained popularity in the testing community because it is good at producing effective and high-quality automated tests.

In this proof-of-concept (POC), we will be exploring the Screenplay Pattern in its simplest form and demonstrating how it can be integrated with Playwright, a powerful test automation tool.

While the Screenplay Pattern is an effective testing approach, it can be challenging to implement correctly, and there may be a learning curve for those unfamiliar with the pattern. It is also worth noting that this POC is not intended to be a comprehensive guide to the Screenplay Pattern or Playwright, and there may be other ways to implement the Screenplay Pattern that better suit your specific testing needs.

Therefore, we recommend that you use this POC as a starting point to learn about the Screenplay Pattern and Playwright and to experiment with different testing approaches to find the best fit for your testing requirements.

Lastly, we would like to reiterate that the Screenplay Pattern is inspired by the Serenity BDD library, and we acknowledge its contributions to the development of this testing design pattern.

## The design pattern

If one were to summarize it in a single sentence, it could be stated that "An **actor** uses his **abilities** to **interact** with **page elements**."

An actor is a representation of a user or system component that interacts with the application being tested. An actor can perform actions on the application and answer questions about its state or behavior.
Actors are typically defined as classes that implement a set of abilities, such as browsing the web or calling an API. These abilities represent the actions that the actor can perform on the application.
Using actors in the Screenplay Pattern allows tests to be written in a more user-focused and understandable way, as the test logic is separated from the implementation details. Additionally, using actors can make tests easier to maintain, as changes to the application's implementation can be made without affecting the test scripts, as long as the abilities, actions, and questions remain the same.

An ability is a specific skill or capability that an actor has to interact with the application being tested. An ability is typically represented as a class that defines the methods or actions that an actor can perform on the application.
The separation of abilities from the rest of the test logic allows tests to be written in a more modular and reusable way. By defining abilities as separate classes, they can be used by multiple actors, actions, and questions, making it easier to maintain and update the test scripts as the application changes.
Overall, abilities play a crucial role in the Screenplay Pattern as they enable actors to interact with the application being tested in a consistent and structured way. 

An action is a specific task or operation that an actor can perform on the application being tested, using the abilities that the actor possesses. An action is typically represented as a class that defines the steps or interactions required to complete the task.
While an ability defines what an actor can do, an action defines what an actor actually does with that ability. Actions are the building blocks of test scripts in the Screenplay Pattern, and they help to separate the details of how an action is performed from the overall test logic. By defining actions as separate classes, they can be reused across different test scripts and make it easier to maintain the tests as the application changes.
Overall, actions work in conjunction with abilities to allow actors to perform specific tasks on the application, and help to make the test scripts more modular and reusable.
