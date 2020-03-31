module.exports = {
  name: 'init-demo',
  preset: '../../jest.config.js',
  coverageDirectory: '../../coverage/apps/init-demo',
  snapshotSerializers: [
    'jest-preset-angular/build/AngularNoNgAttributesSnapshotSerializer.js',
    'jest-preset-angular/build/AngularSnapshotSerializer.js',
    'jest-preset-angular/build/HTMLCommentSerializer.js'
  ]
};
