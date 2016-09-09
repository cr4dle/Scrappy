var path = require("path");

module.exports = {
    entry: ["./controllers/userInputController.js"],
    output: {
        path: path.resolve(__dirname, "dist"),
        publicPath: "/assets/",
        filename: "bundle.js"
    },
    module: {
        loaders: [
            { test: /\.css$/, loader: "style!css" }
        ]
    },
    devServer: {
        inline: true
    }
};