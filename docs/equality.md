#Rules For Framework Equality Checking

##Is it a reference type (class)
  1. Does the type implement IEquatable<T> - use its impl 
  2. Does the type override Equals - use it 
  3. Do they share same memory space (default implementation)

##Is it a value type (struct)
  1. Does the type implement IEquatable<T> - use its impl 
  2. Does the type override Equals - use it 
  3. Reflective field by field equals comparison
