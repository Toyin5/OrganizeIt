# OrganizeIt

OrganizeIt is an open-source project designed to help you organize and manage your files efficiently. This tool allows you to categorize, move, and rename files based on various criteria.

## Features

- **Automatic File Sorting**: Automatically sort files into folders based on file type or custom rules.
- **Batch Renaming**: Rename multiple files at once using customizable patterns.
- **File Filtering**: Filter files by type, size, date, and other attributes.
- **User-Friendly Interface**: Easy-to-use interface for managing your files.
- **Custom Rules**: Create and apply custom rules for organizing files. 

By default, a default config.json ships with the program [config](https://github.com/Toyin5/OrganizeIt/blob/main/OrganizeIt.Cli/config.json) which is a basic config.
config.json follows this structure:
```json
    {
    "Configurations": [
        {
            "DirectoryName": "Your preferred folder name",
            "Extensions": [".pdf", ".docx", ".txt"]
        },
        {
            "DirectoryName": "Your preferred folder name",
            "Extensions": [".jpg", ".png", ".gif"]
        },
        {
            "DirectoryName": "Videos",
            "Extensions": [".mp4", ".avi"]
        },
        {
            "DirectoryName": "Applications",
            "Extensions": [".exe", ".msi"]
        }
    ]
    }
```

The app currently supports organization by extensions. I'm working on making it more flexible

## Installation

To install OrganizeIt, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/Toyin5/OrganizeIt
    ```
2. Navigate to the project directory:
    ```bash
    cd OrganizeIt
    ```
3. Install the required dependencies:
    ```bash
    dotnet restore
    ```

## Usage

- A standalone executable

> To use the standalone executable, you will need to download the zipped files in release and run it in your preferred directory



## Contributing

We welcome contributions from the community! To contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bugfix:
    ```bash
    git checkout -b feature-name
    ```
3. Commit your changes:
    ```bash
    git commit -m "Description of your changes"
    ```
4. Push to the branch:
    ```bash
    git push origin feature-name
    ```
5. Create a pull request.

## License

This project is licensed under the GNU AFFERO GENERAL PUBLIC LICENSE. See the [LICENSE](https://www.gnu.org/licenses/) file for details.

## Contact

For any questions or suggestions, please open an issue or contact us at [email](mailto:toyinmuhammed50@gmail.com).