const gulp = require('gulp'),
    options = require('gulp-options'),
    pump = require('pump');

module.exports = (configuration) => {

    gulp.task('copy:assets', () => {
        if (options.has('dev')) {
            return pump([
                gulp.src(configuration.assets.all),
                gulp.dest(configuration.dev.path + '/' + configuration.assets.name)
            ]);
        }

        if (options.has('dist')) {
            return pump([
                gulp.src(configuration.assets.all),
                gulp.dest(configuration.dist.path + configuration.assets.name)
            ]);
        }

    });

    gulp.task('copy:html', () => {
        if (options.has('dev')) {
            return pump([
                gulp.src(configuration.html.all),
                gulp.dest(configuration.dev.path + configuration.app.name)
            ]);
        }

        if (options.has('dist')) {
            return pump([
                gulp.src(configuration.html.all),
                gulp.dest(configuration.dist.path + configuration.app.name)
            ]);
        }

    });

};