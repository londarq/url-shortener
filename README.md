# url-shortener
.NET Core 7 + Angular 15 app with authentication by JWT

Capabilities:
  - Unauthorized visitor can view home page with urls table and copy shortened urls, view about page and login

`home`
![image](https://github.com/londarq/url-shortener/assets/80911856/de0fb543-b836-4e29-bfba-38b76b722292)

`about (Razor page from backend)`
![image](https://github.com/londarq/url-shortener/assets/80911856/25484fa1-8cfc-4c5e-bf07-76cd2f12d62a)

`login`
![image](https://github.com/londarq/url-shortener/assets/80911856/375fe59c-83e3-456c-80bc-949d7ee9e348)

  - Authorized users additionally can add new urls to database and delete ulrs they've created, logout

![image](https://github.com/londarq/url-shortener/assets/80911856/f81f6541-63eb-4f52-8e90-12c3b2ff8296)

  - Admin users additionally can delete any ulrs and edit app description

`home`
![image](https://github.com/londarq/url-shortener/assets/80911856/aca2a927-c129-42d4-9bec-70c59ace6b7d)

`about (Razor page from backend)`
![image](https://github.com/londarq/url-shortener/assets/80911856/51bcf781-a1ae-4b7d-9191-c7e92aedc849)
  - Currently no sign up, two hardcoded users: `admin` `Admin@123`, `user` `User@123`. Feel free to login and try different roles

Notes:
  - If you get `[webpack-dev-server] Error occurred while proxying request localhost` on start, just refresh the page. There is some delay in proxy i haven't figured out by now
