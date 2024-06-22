# SQLPWAudit
SQLPWAudit (SQL PassWord Audit) is a very simple-to-use tool for recovering simple passwords or performing internal security audits.

Of course, a recovery/auditing engine is only about one third of the battle, you'll also need a good word list (see below) and one other thing which I cannot provide you: time!

Explanation of functionality
SQLPWAudit is a very simple application, but it also implements parallel-processing capabilities and one hell of a permutation engine. Its use is simple: (1) download the application, (2) fire up the application and login to a SQL Server using an administrators account, (3) select the users which you wish to audit, (4) set advanced settings/or leave them alone then (5) click start.

All processing is performed on the computer which is actually running SQLPWAudit - in fact, the SQL server is only accessed one time to grab the users and their binary passwords - so this is perfectly safe to execute against a production server as long as SQLPWAudit is actually running on a non-production system.

Be sure to grab the most up-to-date version of our password list here:
- [Word List Up to 3 Characters.zip](https://networkdls.com/DirectDownload/Word List Up to 3 Characters.zip)
- [Word List Up to 4 Characters.zip](https://networkdls.com/DirectDownload/Word List Up to 4 Characters.zip)
- [Word List Up to 6 Characters.zip](https://networkdls.com/DirectDownload/Word List Up to 6 Characters.zip)
- [Word List Up to 8 Characters.zip](https://networkdls.com/DirectDownload/Word List Up to 8 Characters.zip)
- [Word List Up to 16 Characters.zip](https://networkdls.com/DirectDownload/Word List Up to 16 Characters.zip)


![image](https://github.com/NTDLS/SQLPWAudit/assets/11428567/580223ef-5e48-4a34-acda-283f54cb6cd8)

![image](https://github.com/NTDLS/SQLPWAudit/assets/11428567/6e0fc3fa-b804-4635-b916-2ca975904a29)

![image](https://github.com/NTDLS/SQLPWAudit/assets/11428567/bfad6a67-86e7-4e49-80e5-169d09438d36)
