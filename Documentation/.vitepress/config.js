export default {
  title: 'Synethia',
  logo: '/logo.png',
  base: '/synethia/',
  description:
    'A basic C# algorithm that can determine the behavior of a user with an application.',
  lastUpdated: true,
  outDir: '../dist',
  head: [['link', { rel: 'icon', href: '/synethia/logo.png' }]],
  themeConfig: {
    nav: [
      { text: 'Guide', link: '/get-started' },
      { text: 'Reference', link: '/reference' },
    ],
    repo: 'Leo-Corporation/Synethia',
    docsDir: 'documentation',
    docsBranch: 'main',
    editLink: {
      pattern:
        'https://github.com/Leo-Corporation/Synethia/edit/main/Documentation/:path',
      text: 'Edit this page on GitHub',
    },
    footer: {
      message: 'Released under the MIT License.',
      copyright: `Copyright © ${new Date().getFullYear()} Devyus`,
    },
    socialLinks: [
      {
        icon: 'github',
        link: 'https://github.com/Leo-Corporation/Synethia',
      },
      {
        icon: 'twitter',
        link: 'https://twitter.com/LeoCorpNews',
      },
      {
        icon: 'youtube',
        link: 'https://www.youtube.com/channel/UC283Dtf6EJ8eKfRoo0ISmqg',
      },
    ],
    outline: [1, 3],
  },
};
