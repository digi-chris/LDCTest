# LDCTest

Example code to meet the Local Data Company's test:

```
Write C# code with unit-tests to process a collection of string values which
are passed to a method which returns a collection of processed strings. The
input strings may be any length and can contain any character. Output strings
must not be null or empty string, should be truncated to max length of 15 chars,
and contiguous duplicate characters in the same case should  be reduced to a
single character in the same case. Dollar sign ($) should be replaced with a
pound sign (£), and underscores (_) and number 4 should be removed. Code should
be test-driven, efficient, re-usable and loosely coupled. The returned
collection must not be null.
```

## About

The example project uses xUnit for the tests, which can be run via Visual
Studio.

The sample code implements an `IStringProcessor` interface to help
loosely-couple the and allow different string processors to be built, however
the unit tests are specific to the conditions of the challenge.

Hope it all works OK!