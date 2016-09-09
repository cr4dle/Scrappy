# Scrappy

Scrappy is a MVC Web API project that allows to scrap information from google. The solution contains a separate Single Page Application project to demostrate how easy is to consume the Scrappy service.

### General information

Scrappy uses a number of open source projects to work properly:

* [AngularJS] - HTML enhanced for web apps!
* [Webpack] - awesome module bundler
* [Uglify] - a JavaScript parser/compressor/beautifier
* [Web API 2] - framework that makes it easy to build HTTP services
* [Ninject] - great UI boilerplate for modern web apps

And of course Scrappy itself is open source with a [public repository]
 on GitHub.

### Installation

Scrappy requires [Node.js](https://nodejs.org/) v4+ to run.

Download and extract the [latest pre-built release](https://github.com/joemccann/dillinger/releases).

Install the dependencies and devDependencies.

```sh
$ cd scrappy/ScrapperWeb
$ npm install -d
```

Start webpack in developer mode
```
npm run dev
```

or live mode
```
npm run live
```

### Architecture
![N|Solid](https://s18.postimg.io/es5hpy5yx/Scrappy_Architecture.png)

### Todos

 - Write Tests
 - Front-end design
 - Persist data
 - Implement other search engines

License
----

MIT

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)


   [AngularJS]: <http://angularjs.org>
   [Webpack]: <https://webpack.github.io/>
   [Web API 2]: <http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api>
   [Ninject]: <http://www.ninject.org/>
   [Uglify]: <https://github.com/mishoo/UglifyJS>

   [public repository]: <https://github.com/cr4dle/Scrappy.git>
