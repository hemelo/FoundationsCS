# Builder Design Pattern

The **Builder** is a creational design pattern that lets you construct complex objects step by step. The pattern allows you to produce different types and representations of an object using the same construction code.

-----

## Applicability

Use the Builder pattern in the following scenarios:

  * **To get rid of a “telescoping constructor”.**
    When you have a constructor with many optional parameters, creating objects becomes inconvenient. This leads to creating multiple constructor overloads, which can be hard to manage.

    For example, consider a `Pizza` class with many optional ingredients:

    ```java
    class Pizza {
        Pizza(int size) { ... }
        Pizza(int size, boolean cheese) { ... }
        Pizza(int size, boolean cheese, boolean pepperoni) { ... }
        // ... and so on
    }
    ```

    The Builder pattern lets you build objects step by step, using only the setters that you really need, avoiding the need for a long list of constructor parameters.

  * **To create different representations of a product.**
    The pattern is useful when the construction of various representations of the product involves similar steps that only differ in the details. For example, building a stone house versus a wooden house involves similar steps (build walls, add roof, install windows) but with different materials and implementations. The base builder interface defines all possible construction steps, and concrete builders implement them for specific representations.

  * **To construct Composite trees or other complex objects.**
    The Builder pattern allows you to construct products step-by-step and even defer some steps. This is particularly useful for building complex structures like an object tree, as you can call construction steps recursively. A key benefit is that the builder doesn't expose the unfinished product, preventing the client from accessing an incomplete or unstable object.

-----

## How to Implement

1.  **Define Common Steps:** Identify the common construction steps for building all available product representations and declare these steps in a base **builder interface**.

2.  **Create Concrete Builders:** For each representation of the product, create a **concrete builder** class that implements the builder interface.

3.  **Implement a Get Result Method:** Each concrete builder should have a method for fetching the result of the construction (e.g., `getResult()`). This method isn't typically in the base interface because different builders might create products that don't share a common interface.

4.  **Create a Director (Optional):** You can create a **Director** class that encapsulates common ways to construct a product. The Director works with a builder object to execute a specific series of construction steps.

5.  **Client Code:** The client creates a builder object and (optionally) a director object. The client passes the builder to the director. The director then uses the builder to construct the object.

6.  **Fetch the Product:** The final product is retrieved from the builder object. The client should fetch the result from the builder, especially if different builders produce different types of products.

-----

## Pros and Cons

### ✅ Pros

  * You can construct objects **step-by-step**, defer construction steps, or run steps recursively.
  * You can **reuse the same construction code** when building various representations of products.
  * **Single Responsibility Principle**. You can isolate complex construction code from the business logic of the product.

### ❌ Cons

  * The overall **complexity of the code increases** since the pattern requires creating multiple new classes (builder interface, concrete builders, and an optional director).

-----

## Relations with Other Patterns

  * **Factory Method, Abstract Factory, and Prototype:** Many designs start with the simpler **Factory Method** and evolve toward **Abstract Factory**, **Prototype**, or **Builder** as they become more complex.

  * **Abstract Factory:** The Builder pattern focuses on constructing complex objects step by step, whereas **Abstract Factory** specializes in creating families of related objects and returns the product immediately.

  * **Composite:** You can use the Builder pattern to construct complex **Composite** trees because you can program its construction steps to work recursively.

  * **Bridge:** You can combine Builder with the **Bridge** pattern. In this case, the director class plays the role of the abstraction, while different builders act as implementations.