const gulp = require('gulp'),
    options = require('gulp-options'),
    del = require('del');


module.exports = (configuration) => {

    gulp.task('clean', () => {
        if (options.has('dist')) {
            return del([configuration.dist.path + '**', '!' + configuration.dist.name], { force: true });
        }

        if (options.has('dev')) {
            return del([configuration.dev.path + '**', '!' + configuration.dev.name], { force: true });
        }
    });

};

