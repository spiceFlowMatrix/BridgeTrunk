module.exports = {
  name: 'course-administration',
  preset: '../../jest.config.js',
  coverageDirectory: '../../coverage/apps/course-administration',
  snapshotSerializers: [
    'jest-preset-angular/build/AngularNoNgAttributesSnapshotSerializer.js',
    'jest-preset-angular/build/AngularSnapshotSerializer.js',
    'jest-preset-angular/build/HTMLCommentSerializer.js'
  ]
};
