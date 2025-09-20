namespace Hemelo.Foundation.Patterns.Creational.Singleton
{
    /// <summary>
    /// Provides a thread-safe singleton instance for managing database connections within the application.
    /// </summary>
    /// <remarks>This class implements the singleton pattern to ensure that only one instance exists
    /// throughout the application's lifetime. Access the singleton instance via the <see cref="Instance"/> property.
    /// This approach is suitable for scenarios where a single, shared database connection or context is required. The
    /// implementation uses double-check locking to guarantee thread safety when initializing the instance.</remarks>
    public class DatabaseSingleton
    {
        /// Stores the single instance of the class
        /// It will be null until it is accessed for the first time
        private static DatabaseSingleton? _instance;

        // This is a thread-safe implementation of the Singleton pattern
        // Preventing multiple threads from creating multiple instances
        // So we use a lock object to synchronize access
        private static readonly Lock _lock = new();

        // Private constructor to prevent instantiation from outside
        private DatabaseSingleton()
        {
            // Database connection initialization logic can go here
        }

        // Public method to get the single instance of the class
        public static DatabaseSingleton Instance
        {
            get
            {
                // Double-check locking to ensure thread safety
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        // Check again and create the instance
                        _instance ??= new DatabaseSingleton();
                    }
                }
                return _instance;
            }
        }
    }
}
