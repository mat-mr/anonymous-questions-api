const gulp = require('gulp'),
    sourcemaps = require('gulp-sourcemaps'),
    babel = require('gulp-babel'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    pump = require('pump'),
    options = require('gulp-options'),
    sass = require('gulp-sass');

module.exports = (configuration) => {

    gulp.task('build:app', () => {
        if (options.has('dev')) {
            return pump([
                gulp.src(configuration.app.all),
                sourcemaps.init(),
                babel(),
                concat('app.js'),
                sourcemaps.write('.'),
                gulp.dest(configuration.dev.path)
            ]);
        }

        if (options.has('dist')) {
            return pump([
                gulp.src(configuration.app.all),
                babel(),
                uglify(),
                concat('app.js'),
                gulp.dest(configuration.dist.path)
            ]);
        }
    });


    gulp.task('build:sass', () => {
        if (options.has('dev')) {
            return pump([
                gulp.src(configuration.sass.all),
                sourcemaps.init(),
                sass().on('error', sass.logError),
                concat('main.css'),
                sourcemaps.write('.'),
                gulp.dest(configuration.dev.path + configuration.assets.css)
            ]);
        }

        if (options.has('dist')) {
            return pump([
                gulp.src(configuration.sass.all),
                sass({ outputStyle: 'compressed' }).on('error', sass.logError),
                concat('main.css'),
                gulp.dest(configuration.dist.path + configuration.assets.css)
            ]);
        }
    });

};