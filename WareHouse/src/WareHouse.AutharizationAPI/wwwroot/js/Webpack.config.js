module.exports = {
    entry: ['babel-polyfill', "./components/main/main.jsx"],

    output: {
        path: __dirname + "/public",
        filename: "main.js"
    },
    module: {
        loaders: [
            {
                //tell webpack to use jsx-loader for all *.jsx files
                test: /\.jsx$/,
                loader: 'jsx-loader?insertPragma=React.DOM&harmony'
            }
        ]
    },
    externals: {
        'react': 'React'
    },
    resolve: {
        extensions: ['', '.js', '.jsx']
    },
    watch: true
};