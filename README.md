# Selenium C# UI Test Suite

![CI](https://github.com/MdApsar01/selenium-csharp-ui-tests/actions/workflows/ci.yml/badge.svg)

End-to-end UI automation framework built with **C#**, **NUnit**, and 
**Selenium WebDriver** — running in a fully automated **GitHub Actions 
CI pipeline** on every push.

---

## Why I Built This

To demonstrate practical UI automation skills using the same stack 
I work with professionally — C#, NUnit, Selenium WebDriver, and 
CI/CD pipelines. Every test follows industry-standard patterns used 
in enterprise test suites.

---

## What This Covers

| Scenario | Tests | Concepts Demonstrated |
|---|---|---|
| Login | 4 | Valid/invalid credentials, empty fields |
| Dropdown | 3 | SelectElement, default state verification |
| Checkboxes | 5 | State checking, conditional clicking, toggle |
| Alerts | 4 | JS alert, confirm, prompt, SwitchTo().Alert() |
| Dynamic Loading | 2 | Explicit wait, visibility vs DOM presence |

**Total: 18 automated test cases**

---

## Architecture

```text
selenium-csharp-ui-tests/
├── .github/
│   └── workflows/
│       └── ci.yml                 # GitHub Actions pipeline
├── README.md
└── selenium-csharp-ui-tests/
    ├── Base/
    │   └── BaseTest.cs            # Chrome setup, implicit wait, teardown
    ├── Pages/                     # Page Object Model — one class per page
    │   ├── LoginPage.cs
    │   ├── DropdownPage.cs
    │   ├── CheckboxPage.cs
    │   ├── AlertPage.cs
    │   └── DynamicLodingPage.cs
    ├── Tests/                     # NUnit test classes — one per feature
    │   ├── LoginTest.cs
    │   ├── DropdownTest.cs
    │   ├── CheckboxTest.cs
    │   ├── AlertTest.cs
    │   └── DynamicLoadingTest.cs
    └── selenium-csharp-ui-tests.csproj
```


---

## Key Patterns Used

**Page Object Model**
Each page has its own class owning locators and actions.
Tests call page methods — never interact with locators directly.
If a locator changes, fix it in one place only.

**Base Class Pattern**
All test classes inherit `BaseTest` which handles browser 
setup and teardown. No duplicate code across test files.

**Explicit vs Implicit Wait**
- Implicit wait (10s) — handles standard element loading
- Explicit wait (WebDriverWait) — handles dynamic/async content
- Never uses Thread.Sleep

**Test Isolation**
Every test navigates fresh via [SetUp].
No test depends on another — eliminates cascading failures.

---

## Tech Stack

- **Language:** C# (.NET 10)
- **Test Framework:** NUnit
- **Browser Automation:** Selenium WebDriver
- **Browser:** Chrome (headless on CI)
- **CI/CD:** GitHub Actions
- **Test Site:** [The Internet - Herokuapp](https://the-internet.herokuapp.com)

---

## Run Locally

**Prerequisites:**
- .NET 10 SDK
- Google Chrome installed

**Clone and run:**
```bash
git clone https://github.com/MdApsar01/selenium-csharp-ui-tests.git
cd selenium-csharp-ui-tests/selenium-csharp-ui-tests
dotnet restore
dotnet test
```

**Run specific category:**
```bash
dotnet test --filter "Category=Login"
dotnet test --filter "Category=Dropdown"
dotnet test --filter "Category=Checkbox"
dotnet test --filter "Category=Alerts"
dotnet test --filter "Category=DynamicLoading"
```

---

## CI Pipeline

Every push to `main` triggers the GitHub Actions workflow:

1. Spins up fresh Ubuntu server
2. Installs .NET 10 and Chrome
3. Builds the project
4. Runs all 18 tests in headless Chrome
5. Uploads test results as artifacts

---

## Author

**Mohamed Apsar S**
QA Automation Test Engineer
[LinkedIn](https://linkedin.com/in/mohamed-apsar-s-1a8b4a214) · 
[GitHub](https://github.com/MdApsar01)