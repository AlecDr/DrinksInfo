<p align="center">
    <h1 align="center">DRINKS INFO 🍹</h1>
</p>

<p align="center">
	<img src="https://img.shields.io/github/license/AlecDr/DrinksInfo?style=flat&logo=opensourceinitiative&logoColor=white&color=0080ff" alt="license">
	<img src="https://img.shields.io/github/last-commit/AlecDr/DrinksInfo?style=flat&logo=git&logoColor=white&color=0080ff" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/AlecDr/DrinksInfo?style=flat&color=0080ff" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/AlecDr/DrinksInfo?style=flat&color=0080ff" alt="repo-language-count">
</p>

<br>

##### 🔗 Table of Contents

- [📍 Overview](#-overview)
- [👾 Features](#-features)
- [🎨 Design Patterns](#-design-patterns)
- [📂 Repository Structure](#-repository-structure)
- [🧩 Modules](#-modules)
- [🚀 Getting Started](#-getting-started)
    - [🔖 Prerequisites](#-prerequisites)
    - [📦 Installation](#-installation)
    - [🤖 Usage](#-usage)
    - [🧪 Tests](#-tests)
- [📌 Project Roadmap](#-project-roadmap)
- [🤝 Contributing](#-contributing)
- [🎗 License](#-license)
- [🙌 Acknowledgments](#-acknowledgments)

---

## 📍 Overview

This project is a solution for a restaurant that allows employees to view and select drinks from a menu provided by an external company's API. The system fetches categories of drinks, lets the user choose a specific drink, and displays detailed information.

---

## 👾 Features

- **Drinks Category Menu**:
  The application will display a list of drink categories fetched from an external API. The user can navigate through the list to select a category.

- **Drink Selection**:
  After selecting a category, users can view a list of drinks available in that category. The drink list is pulled dynamically from the external API.

- **Drink Detail View**:
  When a drink is selected, a detailed view will be shown. It will present information such as drink name, ingredients, and price, ensuring that no empty or null properties are displayed.

- **API Integration**:
  The system connects to the external API to fetch drink categories and details. It uses asynchronous programming (async/await) for efficient communication and error handling.

- **Error Handling**:
  Clear, user-friendly error messages will be displayed in case of API failures, empty categories, or missing data. The system will gracefully handle such scenarios.

- **Unit Testing**:
  The service and repository layers are tested with unit tests. API calls will be mocked to simulate different responses and scenarios.


---

## 🎨 Design Patterns 

This project leverages key architectural patterns to ensure maintainability and scalability:

- **Helpers**: Used to simplify access for the most commonly used functionalities accross the application.
- **DTOs (Data Transfer Objects)**: Used to encapsulate data and send it between different layers of the application.
- **Repositories**: Abstracts and encapsulates all access to the data source, providing a clear separation between the business logic and database access code.
- **Services**: Abstracts and encapsulates all business logic for the application.
---

## 📂 Repository Structure

```sh
└── DrinksInfo/
    ├── DrinksInfo.sln
    ├── LICENSE.txt
    ├── Main
    │   ├── Data
    │   ├── Helpers
    │   ├── Main.csproj
    │   ├── Menus
    │   ├── Program.cs
    │   └── Services
    └── Tests
        ├── Helpers
        ├── Tests
        └── Tests.csproj
```

---

## 🧩 Modules

<details closed><summary>.</summary>

| File | Summary |
| --- | --- |
| [LICENSE.txt](https://github.com/AlecDr/DrinksInfo/blob/main/LICENSE.txt) | <code>❯ REPLACE-ME</code> |
| [DrinksInfo.sln](https://github.com/AlecDr/DrinksInfo/blob/main/DrinksInfo.sln) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main</summary>

| File | Summary |
| --- | --- |
| [Main.csproj](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Main.csproj) | <code>❯ REPLACE-ME</code> |
| [Program.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Program.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Menus</summary>

| File | Summary |
| --- | --- |
| [DrinkDetailsScreen.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Menus/DrinkDetailsScreen.cs) | <code>❯ REPLACE-ME</code> |
| [MainMenu.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Menus/MainMenu.cs) | <code>❯ REPLACE-ME</code> |
| [DrinksScreen.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Menus/DrinksScreen.cs) | <code>❯ REPLACE-ME</code> |
| [CategoriesScreen.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Menus/CategoriesScreen.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Menus.Interfaces</summary>

| File | Summary |
| --- | --- |
| [IScreen.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Menus/Interfaces/IScreen.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Services.Interfaces</summary>

| File | Summary |
| --- | --- |
| [IDrinksService.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Services/Interfaces/IDrinksService.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Services.Implementations</summary>

| File | Summary |
| --- | --- |
| [DrinksService.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Services/Implementations/DrinksService.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Data.Repositories.Interfaces</summary>

| File | Summary |
| --- | --- |
| [IImagesRepository.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/Repositories/Interfaces/IImagesRepository.cs) | <code>❯ REPLACE-ME</code> |
| [ICategoryRepository.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/Repositories/Interfaces/ICategoryRepository.cs) | <code>❯ REPLACE-ME</code> |
| [IDrinkRepository.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/Repositories/Interfaces/IDrinkRepository.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Data.Repositories.Implementations</summary>

| File | Summary |
| --- | --- |
| [DrinkRepository.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/Repositories/Implementations/DrinkRepository.cs) | <code>❯ REPLACE-ME</code> |
| [CategoryRepository.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/Repositories/Implementations/CategoryRepository.cs) | <code>❯ REPLACE-ME</code> |
| [ImagesRepository.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/Repositories/Implementations/ImagesRepository.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Data.DTOs</summary>

| File | Summary |
| --- | --- |
| [RootResponseDTO.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/DTOs/RootResponseDTO.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Data.DTOs.Drinks</summary>

| File | Summary |
| --- | --- |
| [DrinkSimplifiedDTO.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/DTOs/Drinks/DrinkSimplifiedDTO.cs) | <code>❯ REPLACE-ME</code> |
| [DrinkCompleteDTO.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/DTOs/Drinks/DrinkCompleteDTO.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Data.DTOs.Categories</summary>

| File | Summary |
| --- | --- |
| [CategoryDTO.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Data/DTOs/Categories/CategoryDTO.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Main.Helpers</summary>

| File | Summary |
| --- | --- |
| [DrinksInfoHelper.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Helpers/DrinksInfoHelper.cs) | <code>❯ REPLACE-ME</code> |
| [ConsoleHelper.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Main/Helpers/ConsoleHelper.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Tests</summary>

| File | Summary |
| --- | --- |
| [Tests.csproj](https://github.com/AlecDr/DrinksInfo/blob/main/Tests/Tests.csproj) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Tests.Tests.Unit</summary>

| File | Summary |
| --- | --- |
| [DrinksServiceTests.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Tests/Tests/Unit/DrinksServiceTests.cs) | <code>❯ REPLACE-ME</code> |
| [CategoryRepositoryTests.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Tests/Tests/Unit/CategoryRepositoryTests.cs) | <code>❯ REPLACE-ME</code> |
| [DrinkRepositoryTests.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Tests/Tests/Unit/DrinkRepositoryTests.cs) | <code>❯ REPLACE-ME</code> |
| [ImagesRepositoryTests.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Tests/Tests/Unit/ImagesRepositoryTests.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>Tests.Helpers</summary>

| File | Summary |
| --- | --- |
| [StaticDrinksJsonHttpMessageHandler.cs](https://github.com/AlecDr/DrinksInfo/blob/main/Tests/Helpers/StaticDrinksJsonHttpMessageHandler.cs) | <code>❯ REPLACE-ME</code> |

</details>

---

## 🚀 Getting Started

### 🔖 Prerequisites

**CSharp**: `version 8.0`

### 📦 Installation

Build the project from source:

1. Clone the DrinksInfo repository:
```sh
❯ git clone https://github.com/AlecDr/DrinksInfo
```

2. Navigate to the project directory:
```sh
❯ cd DrinksInfo
```

3. Install the required dependencies:
```sh
❯ dotnet build
```

### 🤖 Usage

To run the project, execute the following command:

```sh
❯ dotnet run
```

### 🧪 Tests

Execute the test suite using the following command:

```sh
❯ dotnet test
```

---

## 📌 Project Roadmap

- [x] **`Task 1`**: Implement Drinks Category Menu to display all categories retrieved from the external API.
- [x] **`Task 2`**: Implement Drink Selection functionality to allow users to choose a drink from the selected category.
- [x] **`Task 3`**: Implement Drink Detail View that excludes empty/null properties and displays only relevant drink information.
- [x] **`Task 4`**: Integrate external API for fetching drinks categories and drink details.
- [x] **`Task 5`**: Implement error handling for API calls and ensure user-friendly messages are displayed.
- [x] **`Task 6`**: Write unit tests for the service and repository layers, mocking the API for test scenarios.

---

## 🤝 Contributing

Contributions are welcome! Here are several ways you can contribute:

- **[Report Issues](https://github.com/AlecDr/DrinksInfo/issues)**: Submit bugs found or log feature requests for the `DrinksInfo` project.
- **[Submit Pull Requests](https://github.com/AlecDr/DrinksInfo/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.
- **[Join the Discussions](https://github.com/AlecDr/DrinksInfo/discussions)**: Share your insights, provide feedback, or ask questions.

<details closed>
<summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your github account.
2. **Clone Locally**: Clone the forked repository to your local machine using a git client.
   ```sh
   git clone https://github.com/AlecDr/DrinksInfo
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to github**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.
8. **Review**: Once your PR is reviewed and approved, it will be merged into the main branch. Congratulations on your contribution!
</details>

<details closed>
<summary>Contributor Graph</summary>
<br>
<p align="left">
   <a href="https://github.com{/AlecDr/DrinksInfo/}graphs/contributors">
      <img src="https://contrib.rocks/image?repo=AlecDr/DrinksInfo">
   </a>
</p>
</details>

---

## 🎗 License

This project is protected under the [MIT](https://choosealicense.com/licenses/mit/) License. For more details, refer to the [LICENSE](https://github.com/AlecDr/FlashCards/blob/master/LICENSE.txt) file.

---

## 🙌 Acknowledgments

- Idea taken from [C# Academy](https://www.thecsharpacademy.com/), nice location to learn C#.

---
