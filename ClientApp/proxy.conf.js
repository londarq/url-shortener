const { env } = require("process");

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
  ? env.ASPNETCORE_URLS.split(";")[0]
  : "http://localhost:58994";

const PROXY_CONFIG = [
  {
    context: ["/about", "/api", "/u", "/account/login"],
    proxyTimeout: 3000,
    target: target,
    secure: false,
    logLevel: "debug",
    headers: {
      Connection: "Keep-Alive",
    },
    pathRewrite: {
      "^/u": "",
    },
  },
];

module.exports = PROXY_CONFIG;
