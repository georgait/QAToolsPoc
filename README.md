# QA Tools (poc)

## Overview

The Screenplay Pattern is a popular design pattern for software testing that tries to give automated testing a modular, scalable, and maintainable approach. It is based on the Serenity BDD library and has gained popularity in the testing community because it is good at producing effective and high-quality automated tests.

In this proof-of-concept (POC), we will be exploring the Screenplay Pattern in its simplest form and demonstrating how it can be integrated with Playwright, a powerful test automation tool.

While the Screenplay Pattern is an effective testing approach, it can be challenging to implement correctly, and there may be a learning curve for those unfamiliar with the pattern. It is also worth noting that this POC is not intended to be a comprehensive guide to the Screenplay Pattern or Playwright, and there may be other ways to implement the Screenplay Pattern that better suit your specific testing needs.

Therefore, i recommend that you use this POC as a starting point to learn about the Screenplay Pattern and Playwright and to experiment with different testing approaches to find the best fit for your testing requirements.

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

## The POC

### Installation

To run the POC, you will need to install the following prerequisites:
1. Specflow plugin for VS:

    a. Open Visual Studio.

    b. Click on Tools > Extensions and Updates.
    
    c. Click on the Online tab and search for SpecFlow for Visual Studio.
    
    d. Click the Download button and follow the installation prompts.

2. Playwright:

    a. `dotnet add package Microsoft.Playwright`
    
    b. `dotnet build`
    
    c. `pwsh bin/Debug/netX/playwright.ps1 install`

### Usage

We start with the base ability class named `BrowseTheWeb`. We initialize Playwright here and assign that ability to our actor. Next, we have the `Actor` class. 
The actor has its own abilities (such as BrowseTheWeb) and can interact with page elements, as well as request anything related to the page.
The method used to interact with a page element is called `Task WhoAttemptsTo(ITask task)`. It takes an `ITask` as an argument and returns a `Task`.
The `ITask` is an interface with one method, `Task PerformTaskAsyncAs(IActor actor)`. 
So, in a step definition, one could use the actor to enter some value on a locator like below:

```
await actor.WhoAttemptsTo(Enter.OnTarget(TopNavBar.SearchDocs).TheValue(text));
```

Here, we need to clarify the usage of `OfTarget(Func<IPage, ILocator> locationAction)`. To take advantage of Playwright's built-in selector methods, 
we use a page object that is a static class, for example: 
```
public static class TopNavBar 
{
    public static ILocator SearchDocs(IPage page)
    {
        return page.GetByPlaceholder("Search docs");
    }
}
```
The `OnTarget` method requires a `Func` parameter with the same method signature as the aforementioned method. By utilizing the "Page object," 
we adhere to the Single Responsibility Principle, as the page object is responsible for providing the ability to retrieve a locator and nothing else.

Similarly, we can query information for the page that is under test. For this to work, we use the other method of actor:

```
Task<T> WhoAsksFor<T>(IQuestion<T> question) where T : class
```

Then, we can use assertions like this:

```
var text = await actor.WhoAsksFor(TheText.OfTarget(TraceViewer.CliCommand));
Assert.AreEqual(command, text);
```

Of course, we can also use lambda like this:

```
.OfTarget(page =>
{
    return page.GetByRole(AriaRole.Code).Filter(new() { HasText = "your-text" }).First;
})

```

Last but not least, with SpecFlow in place, we use its bindings for `BeforeTestRun` and `AfterScenario`. Before the test run, we set up the configuration (appsettings.json), and after the scenario, we dispose all abilities of any actor. 
It is important to note that we use `BoDi` as our DI container, which is the built-in DI container of SpecFlow.

### Disclaimer

This is just a POC and is not meant to be used as is in a real testing context. So there is definitely room for improvement.
