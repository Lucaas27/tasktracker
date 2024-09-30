<h1 align="center">TaskTracker</h1>

<p align="center">
  <img alt="Github top language" src="https://img.shields.io/github/languages/top/Lucaas27/tasktracker?color=56BEB8">

  <!-- <img alt="Github language count" src="https://img.shields.io/github/languages/count/Lucaas27/tasktracker?color=56BEB8"> -->

  <img alt="Repository size" src="https://img.shields.io/github/repo-size/Lucaas27/tasktracker?color=56BEB8">

  <!-- <img alt="License" src="https://img.shields.io/github/license/Lucaas27/tasktracker?color=56BEB8"> -->

  <!-- <img alt="Github issues" src="https://img.shields.io/github/issues/Lucaas27/tasktracker?color=56BEB8" /> -->

  <!-- <img alt="Github forks" src="https://img.shields.io/github/forks/Lucaas27/tasktracker?color=56BEB8" /> -->

  <!-- <img alt="Github stars" src="https://img.shields.io/github/stars/Lucaas27/tasktracker?color=56BEB8" /> -->
</p>

<!-- Status -->

<!-- <h4 align="center">
	🚧  TaskTracker 🚀 Under construction...  🚧
</h4>

<hr> -->

<p align="center">
  <a href="#dart-about">About</a> &#xa0; | &#xa0;
  <a href="#sparkles-features">Features</a> &#xa0; | &#xa0;
  <a href="#rocket-technologies">Technologies</a> &#xa0; | &#xa0;
  <a href="#white_check_mark-requirements">Requirements</a> &#xa0; | &#xa0;
  <a href="#checkered_flag-starting">Starting</a> &#xa0; | &#xa0;
  <!-- <a href="#memo-license">License</a> &#xa0; | &#xa0; -->
  <a href="https://github.com/Lucaas27" target="_blank">Author</a>
</p>

<br>

## :dart: About

TaskTracker is .NET 8 a console-based task management application that supports both interactive and non-interactive modes. It allows users to add, update, delete, list, and mark tasks with various statuses. The application can save tasks in both JSON and TXT formats.

It is a [challenge](https://roadmap.sh/projects/task-tracker) from [roadmap.sh](https://roadmap.sh/).

Project Task URL : <https://roadmap.sh/projects/task-tracker>

## :sparkles: Features

:heavy_check_mark: Add a New Task: Create new tasks with a simple command\
:heavy_check_mark: Delete Task: Remove tasks by their ID.\
:heavy_check_mark: Update Task: Modify the description of an existing task.\
:heavy_check_mark: Change Task Status: Mark tasks as "To-Do", "In-Progress" or "Done".\
:heavy_check_mark: List Tasks: Display all tasks or filter tasks by status.

- **Interactive Mode**: Allows users to interact with the application through prompts and inputs.
- **Non-Interactive Mode**: Allows users to execute commands directly via command-line arguments.
- **Task Persistence**: Supports saving tasks in both JSON and TXT formats.

## :white_check_mark: Requirements

Before starting :checkered_flag:, you need to have installed:

1. **Git**
2. **.NET SDK**: Install the .NET SDK, which includes the .NET runtime and command-line tools.
3. **Code Editor**: A code editor like Visual Studio Code or Visual Studio.

## :checkered_flag: Starting

```bash
# Clone this project
$ git clone https://github.com/Lucaas27/tasktracker

# Access
$ cd tasktracker

# Restore dependencies
$ dotnet restore

# Build the project
$ dotnet build

# Run the application
$ dotnet run

```

### Commands

#### Add Task

- **Interactive Mode**: Prompts the user to enter a task description.
- **Non-Interactive Mode**: Adds a new task with the provided description.

  `add <description>`

#### Update Task

- **Interactive Mode**: Prompts the user to enter the task ID and the new description.
- **Non-Interactive Mode**: Updates an existing task with the provided ID and description.

  `update <id> <description>`

#### Delete Task

- **Interactive Mode**: Prompts the user to enter the task ID to delete.
- **Non-Interactive Mode**: Deletes the task with the provided ID.

  `delete <id>`

#### List All Tasks

- **Interactive Mode**: Lists all tasks.
- **Non-Interactive Mode**: Lists all tasks.

  `list`

#### List Tasks by Status

- **Interactive Mode**: Prompts the user to select a status and lists tasks with that status.
- **Non-Interactive Mode**: Lists tasks with the provided status.

  `status <status>`

#### Mark Task Status

- **Interactive Mode**: Prompts the user to enter the task ID and select a new status.
- **Non-Interactive Mode**: Marks the task with the provided ID and status.

  `mark <id> <status>`

#### Display Help

- **Non-Interactive Mode**: Displays available commands and their descriptions.

  `help`

#### Exit

- **Non-Interactive Mode**: Exits the application.

  `exit`

### Example Commands

- Add a task:

  `add Buy groceries`

- Update a task:

  `update 1 Buy groceries and cook dinner`

- Delete a task:

  `delete 1`

- List all tasks:

  `list`

- List tasks by status:

  `status todo`

- Mark a task status:

  `mark 1 done`

- Display help:

  `help`

- Exit the application:

  `exit`

&#xa0;

<a href="#top">Back to top</a>
