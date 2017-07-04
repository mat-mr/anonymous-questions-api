const gulp = require('gulp'),
    pump = require('pump'),
    useref = require('gulp-useref'),
    options = require('gulp-options');

module.exports = (configuration) => {

    gulp.task('useref', () => {
        if (options.has('dev')) {
            return pump([
                gulp.src(configuration.index.path),
                useref(),
                gulp.dest(configuration.dev.path)
            ]);
        }

        if (options.has('dist')) {
            return pump([
                gulp.src(configuration.index.path),
                useref(),
                gulp.dest(configuration.dist.path)
            ]);
        }
    });

};
