import { RouteConfig, NavigationGuard } from 'vue-router';

export default (requireAuth: NavigationGuard): RouteConfig[] => {
  return [
    {
      path: '/products',
      component: () => import('./Products.vue'),
      beforeEnter: requireAuth,
      children: [
        {
          path: '',
          name: 'products-list',
          component: () => import('./ProductsList.vue')
        },
        {
          path: 'add',
          name: 'products-add',
          component: () => import('./ProductsForm.vue')
        },
        {
          path: ':id',
          name: 'products-edit',
          component: () => import('./ProductsForm.vue'),
          props: true
        },
        {
          path: ':productId/add',
          name: 'flags-add',
          component: () => import('./flags/FlagsForm.vue'),
          props: true
        },
        {
          path: ':productId/:id',
          name: 'flags-edit',
          component: () => import('./flags/FlagsForm.vue'),
          props: true
        },
        {
          path: ':productId/:id/add',
          name: 'toggles-add',
          component: () => import('./flags/toggles/TogglesForm.vue'),
          props: true
        },
        {
          path: ':productId/:id/:toggleId',
          name: 'toggles-edit',
          component: () => import('./flags/toggles/TogglesForm.vue'),
          props: true
        }
      ]
    }
  ];
};
