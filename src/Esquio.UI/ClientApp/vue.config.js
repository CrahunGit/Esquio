const path = require('path');
const webpack = require('webpack');
// const rules = require('require.all')('./tasks/rules');
const plugins = require('require.all')('./tasks/plugins');

module.exports = env => {
  let environment = process.env.NODE_ENV;

  // rules((name, rule) => rule(environment));
  plugins((name, rule) => rule(environment));

  return ({
    lintOnSave: false,
    css: {
      loaderOptions: {
        sass: {
          data: `@import "~@/styles/base/_variables.scss";`
        }
      }
    },
    configureWebpack: {
      externals: ['window'],
      plugins: [
        // For Bootstrap material
        new webpack.ProvidePlugin({
          $: 'jquery',
          jQuery: 'jquery',
          Popper: ['popper.js', 'default'],
        })
      ],
      optimization: {
        splitChunks: {
          cacheGroups: {
            vendor: {
              chunks: 'all',
              test: path.resolve(__dirname, 'node_modules'),
              name: 'vendor',
              enforce: true,
            },
          },
        },
      },
      resolve: {
        alias: {
          'styles': path.join(__dirname, 'src/styles'),
          'assets': path.join(__dirname, 'src/assets'),
          '~': path.join(__dirname, 'src/app')
        }
      }
    },
    chainWebpack: config => {
        config.optimization.minimizer([plugins.terser]);
    }
  })
}
