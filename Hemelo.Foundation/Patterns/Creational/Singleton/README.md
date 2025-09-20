# Singleton Pattern

## Applicability

- Use the **Singleton** pattern when a class should have only one instance available to all clients.  
  Example: a single database connection shared across different parts of a program.

- The Singleton pattern disables all other means of creating objects of a class, except through a special creation method.  
  - This method either **creates a new object** or **returns the existing one** if it has already been created.

- Use it when you need stricter control over global variables.  
  Unlike global variables, the Singleton guarantees that:
  - Only one instance of a class exists.
  - Nothing (except the Singleton class itself) can replace the cached instance.

> 💡 You can adjust the restriction to allow multiple instances by modifying only the `getInstance` method.

---

## How to Implement

1. Add a **private static field** to the class for storing the singleton instance.  
2. Declare a **public static creation method** for retrieving the instance.  
3. Implement **lazy initialization** inside this method:  
   - On first call → create the object and store it in the static field.  
   - On later calls → return the stored instance.  
4. Make the **constructor private** so no external objects can create instances.  
   - Only the static method can access it.  
5. Update client code to call the **static creation method** instead of the constructor.

---

## Pros

- ✅ Guarantees a class has only one instance.  
- ✅ Provides a global access point to that instance.  
- ✅ Supports lazy initialization (instance created only when needed).

---

## Cons

- ❌ Violates the **Single Responsibility Principle** (manages both instance creation and business logic).  
- ❌ Can mask poor design (tight coupling between components).  
- ❌ Requires extra handling in **multithreaded environments** to avoid multiple instances.  
- ❌ Harder to **unit test**:
  - Private constructors prevent mocking through inheritance.  
  - Static methods can’t be easily overridden in most languages.  
  - Workarounds are needed, or you may need to avoid Singleton altogether.

---

## Relationship with Other Patterns

- A **Facade** class can often be transformed into a **Singleton**, since a single facade object is sufficient in most cases.  

- **Flyweight** would resemble Singleton if all shared states of the objects were reduced to just one flyweight object.  
  However, there are two key differences:
  1. There should be only **one Singleton** instance, while a Flyweight class can have **multiple instances** with different intrinsic states.  
  2. The **Singleton object can be mutable**, whereas Flyweight objects are **immutable**.  

- **Abstract Factories**, **Builders**, and **Prototypes** can all be implemented as Singletons.