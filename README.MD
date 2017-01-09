# MClam [![Build Status](https://travis-ci.org/fahminlb33/MClam.svg?branch=master)](https://travis-ci.org/fahminlb33/MClam)
Fully managed libclamav wrapper, written in C#


## What is this?

This is the most up-to-date `libclamav` wrapper to add virus scanning
abilities for your applications.

This library is fully re-written from MClam successor `SharpClam` 
and `ReSharpedClam` which is likely non-stable and had many memory leaks. 
Well coded using C# with great documentation. I hope this library would
be useful for you.

## How to use

Clone this repo and open up the solution file to see examples.

**Warning!** This library is platform-dependent. You need to use right
dlls to make this library works. Use right *Build Configuration* (x86 or x64)
based on your `libclamav` platform.

When you selected wrong build config, it's likely you will get `BadImageFormatException`
due to mismatch image format (x86 and x64 image).

## Features

* File scanning **(libclamav)**
* Database verification, updates **(freshclam)**, and monitoring **(libclamav)**
* Database signature creation **(sigtool)**


## What's next?

* Create unit tests
* Implement async version of file scanning
* Add more database host mirror in `Freshclam`
* Implement more signature generation in `Sigtool`
* Create more example project and code snippets

This library is still *work-in-progress*. Use at your attention.