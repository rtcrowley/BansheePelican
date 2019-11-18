# BansheePelican
A Forensic C# console app that parses BITS metadata and displays the results via CLI. Just set the full Windows path to whatever BITS log you'd wish to investigate with the -p switch. These can be files that were copied, or files located in the default ```C:\ProgramData\Microsoft\Network\Downloader\``` directory.

The goal was to make a lightweight app that would produce simple output in a easy to ready format. Although, due to all the unique characters in BITS dat files, some strings may be *slightly* mangled.

**Outputs:**
* All HTTP and HTTPS Strings
* Unique HTTP and HTTPS Strings
* Downloaded files from BITS jobs - excluding default BITS tmp files.
* Also works with edb or similarly formatted logs

![alt text](https://rtcrowley.github.io/bapeli2.png?raw=true "bits parser")
