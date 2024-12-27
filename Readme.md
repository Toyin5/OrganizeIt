# OrganizeIt

OrganizeIt is an open-source project designed to help you organize and manage your files efficiently. This tool allows you to categorize, move, and rename files based on various criteria.

## Features

- **Automatic File Sorting**: Automatically sort files into folders based on file type or custom rules.
- **Batch Renaming**: Rename multiple files at once using customizable patterns.
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

The app currently supports organization by extensions. I'm working on making it more flexible.

## How to use it?
⚠️ You will need [Chocolatey](https://chocolatey.org/install) to run it

- Download the package on chocolatey
    ```bash
    choco install organizeit --version=1.0.0
    ```
- Navigate to your target directory
  ```bash
  cd path/to/your/target/directory
  ```
- Run organizeit.cli
    ```bash
    > organizeit.cli
    ```
    ⚠️Note: This run with the default configuration which is: 
    
    ```json
    {
            "Configurations": [
                {
                "DirectoryName": "Documents",
                "Extensions": [".pdf", ".docx", ".txt"]
                },
                {
                "DirectoryName": "Images",
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

### To run with your desired configurations, you can either create a config.json file inside the target directory or specify the path to it using the -c option.
- Create a custom config.json at the root of the targeted directory that follow the above config then run:
```bash
> organizeit.cli
```
- Speciffy the path to the custome config.json using the -c flag
```bash
> organizeit.cli -c path/to/the/custom/config/file
```
You can also check the available commands by passing --help
```bash
> organizeit.cli --help
```
```bash
    -c, --config       Set the config file

    -d, --directory    Set the target directory

    --help             Display this help screen.

    --version          Display version information.
```
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