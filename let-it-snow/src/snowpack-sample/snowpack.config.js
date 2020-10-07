module.exports = {
    mount: {
        public: '/',
        src: '/_dist_',
    },
    plugins: [
        '@snowpack/plugin-react-refresh',
        '@snowpack/plugin-dotenv',
        ["@snowpack/plugin-run-script", {
            "cmd": "node-sass ./src/sass/style.sass ./src/index.css",
            "watch": "$1 --watch"
        }]
    ],
};
